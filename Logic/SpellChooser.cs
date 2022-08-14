using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABI.Windows.Data.Pdf;
using DOS2Randomizer.DataStructures;
using Attribute = DOS2Randomizer.DataStructures.Attribute;
using Pdf = System.Collections.Generic.Dictionary<DOS2Randomizer.DataStructures.IConstSpell, double>;
using Cdf = System.Collections.Generic.List<System.ValueTuple<double, DOS2Randomizer.DataStructures.IConstSpell>>;

namespace DOS2Randomizer.Logic {
    internal static class RandomExtension {
        public static IEnumerable<T> ChooseRandom<T>(this IEnumerable<T> source, int num) {
            var rng = new Random();
            return source.OrderBy(arg => rng.Next()).Take(num).ToList();
        }
    }

    public class SpellChooser {
        private readonly IMatchProperties _matchConfig;
        private readonly IConstPlayer _player;
        private readonly int _numSpellsToGenerate;
        private const double AttributeFactor = 2.5; // One level point is worth roughly <value> AttributePoints
        private const double SkillPointFactor = 0.8; // One level point is worth roughly <value> AttributePoints

        public SpellChooser(IMatchProperties matchConfig, IConstPlayer player) {
            _matchConfig = matchConfig;
            _numSpellsToGenerate = _matchConfig.N;
            _player = player;
        }

        private int SkillPointDifference(IConstSpell spell) {
            int ret = 0;
            foreach (var (school, val) in _player.SkillPoints) {
                ret += Math.Max(spell.SchoolRequirements[school] - val, 0);
            }

            return ret;
        }

        private bool Learnable(IConstSpell spell, int maxSkillDiff) {
            return spell.Level <= _player.Level && SkillPointDifference(spell) < maxSkillDiff &&
                   (spell.CDependencies.IsEmpty || spell.CDependencies.Intersect(_player.CKnownSpells).Any()) &&
                   _player.PossibleSkillTypes.Contains(spell.EquipmentRequirement) &&
                   !_player.CKnownSpells.Contains(spell);
        }

        private double Gaussian(double x, double std) {
            return Math.Exp(-Math.Pow(x, 2) / std);
        }

        private Pdf Weighting(IEnumerable<IConstSpell> spells, Func<IConstSpell, double> likelihoodFunc) {
            var ret = new Pdf();
            double sum = 0;
            foreach (var spell in spells) {
                var likelihood = likelihoodFunc(spell);
                sum += likelihood;
                ret.Add(spell, likelihood);
            }

            foreach (var spell in ret.Keys) {
                ret[spell] /= sum;
            }

            return ret;
        }

        private Pdf LevelWeighting(IEnumerable<IConstSpell> spells, double importance) {
            if (importance is < 0 or > 1) {
                throw new ArgumentException("importance must be in [0, 1]");
            }

            return Weighting(spells, spell => Gaussian(spell.Level - _player.Level, importance));
        }

        private Pdf AttributeWeighting(IEnumerable<IConstSpell> spells, double importance) {
            if (importance is < 0 or > 1) {
                throw new ArgumentException("importance must be in [0, 1]");
            }

            var maxAttributeVal = _player.Attributes.Values.Max();
            return Weighting(spells, spell => {
                if (spell.Scaling is not Attribute.None) {
                    return Gaussian(_player.Attributes[spell.Scaling] - maxAttributeVal, importance * AttributeFactor);
                }

                return 1;
            });
        }

        private Pdf SkillPointsWeighting(IEnumerable<IConstSpell> spells, double importance) {
            if (importance is < 0 or > 1) {
                throw new ArgumentException("importance must be in [0, 1]");
            }

            int maxSkillVal = _player.SkillPoints.Values.Max();
            return Weighting(spells, spell => {
                if (BenefitsFrom(spell) is { } benefit) {
                    return Gaussian(_player.SkillPoints[benefit] - maxSkillVal, importance);
                }

                return 1;
            });
        }

        //@TODO implementation
        private Pdf SkillTypeWeighting(IEnumerable<IConstSpell> spells, double importance) {
            if (importance is < 0 or > 1) {
                throw new ArgumentException("importance must be in [0, 1]");
            }

            var ret = spells.ToDictionary(spell => spell, _ => 1.0);
            return ret;
        }

        private Pdf PdfProduct(IEnumerable<Pdf> pdfs) {
            var allPdfs = pdfs.ToArray();
            var ret = allPdfs.First().Keys.ToDictionary(spell => spell, _ => 1.0);
            double sum = 0;
            foreach (var key in ret.Keys) {
                foreach (var pdf in allPdfs) {
                    ret[key] *= pdf[key];
                }

                sum += ret[key];
            }

            foreach (var key in ret.Keys) {
                ret[key] /= sum;
            }

            return ret;
        }

        private void Normalize(Pdf pdf) {
            double sum = pdf.Values.Sum();
            foreach (var key in pdf.Keys) {
                pdf[key] /= sum;
            }
        }

        //@TODO additional spell info needed
        private Spell.School? BenefitsFrom(IConstSpell spell) {
            var primarySchoolType = spell.SchoolRequirements.MaxBy(pair => pair.Value).Key;
            return primarySchoolType switch {
                Spell.School.Aero => Spell.School.Aero,
                Spell.School.Hydro => Spell.School.Hydro,
                Spell.School.Pyro => Spell.School.Pyro,
                Spell.School.Geo => Spell.School.Geo,
                Spell.School.Scoundrel => Spell.School.Warfare,
                Spell.School.Warfare => Spell.School.Warfare,
                Spell.School.Poly => null,
                Spell.School.Huntsman => Spell.School.Warfare,
                Spell.School.Necro => Spell.School.Warfare,
                Spell.School.Summoning => Spell.School.Summoning,
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        private Cdf GenerateCdf(Pdf pdf) {
            var ret = new Cdf();
            double accVal = 0;
            foreach (var (spell, prob) in pdf) {
                accVal += prob;
                ret.Add(ValueTuple.Create(accVal, spell));

            }

            return ret;
        }

        public IEnumerable<IConstSpell> GetSpells() {

            const int maxSkillPointDifference = 2;
            var allPossibleSpells = _matchConfig.CSpells.Where(spell => Learnable(spell, maxSkillPointDifference))
                .ToArray();
            var spellPdf = PdfProduct(new[] {
                LevelWeighting(allPossibleSpells, 0.5),
                AttributeWeighting(allPossibleSpells, 0.5),
                SkillPointsWeighting(allPossibleSpells, 0.5),
                SkillTypeWeighting(allPossibleSpells, 0.5)
            });

            var cdf = GenerateCdf(spellPdf);
            var ret = new IConstSpell[_numSpellsToGenerate];
            var rng = new Random();
            for (int i = 0; i < _numSpellsToGenerate; ++i) {
                ret[i] = cdf.First(tuple => tuple.Item1 >= rng.NextDouble()).Item2;
                spellPdf.Remove(ret[i]);
                Normalize(spellPdf);
                cdf = GenerateCdf(spellPdf);
            }

            return ret;
        }
    }
}
