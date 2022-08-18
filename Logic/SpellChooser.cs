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
        #region fields

        private readonly IMatchProperties _matchConfig;
        private readonly IConstPlayer _player;
        private readonly int _numSpellsToGenerate;
        public const double LevelFactor = 1;
        public const double AttributeFactor = 2.5 * LevelFactor; // One level point is worth roughly <value> AttributePoints
        public const double SkillPointFactor = 0.8 * LevelFactor; // One level point is worth roughly <value> AttributePoints
        private const double NoWeightingLikelihood = 0.5;

        #endregion

        public SpellChooser(IMatchProperties matchConfig, IConstPlayer player) {
            _matchConfig = matchConfig;
            _numSpellsToGenerate = _matchConfig.N;
            _player = player;
        }

        #region util

        private int SkillPointDifference(IConstSpell spell) {
            int ret = 0;
            foreach (var (school, val) in _player.SkillPoints) {
                ret += Math.Max(spell.SchoolRequirements[school] - val, 0);
            }

            return ret;
        }

        private bool PlayerCanWield(IConstSpell spell) {
            return spell.EquipmentRequirement == Player.SkillType.None ||
                   _player.PossibleSkillTypes.Contains(spell.EquipmentRequirement) ||
                   (spell.EquipmentRequirement == Player.SkillType.Melee &&
                    _player.PossibleSkillTypes.Contains(Player.SkillType.Dagger));
        }

        private bool Learnable(IConstSpell spell, int maxSkillDiff) {
            return spell.Level <= _player.Level && SkillPointDifference(spell) < maxSkillDiff &&
                   (spell.CDependencies.IsEmpty || spell.CDependencies.Intersect(_player.CKnownSpells).Any()) &&
                   PlayerCanWield(spell) && !_player.CKnownSpells.Contains(spell);
        }

        public static double Gaussian(double x, double std) {
            return Math.Exp(-Math.Pow(x, 2) / std);
        }

        private Attribute GetScalingAttribute(IConstSpell spell) {
            if (spell.Scaling == Attribute.Weapon) {
                if (_player.DmgType == Player.WeaponDmgType.Magical) {
                    return Attribute.Int;
                }

                if (_player.PossibleSkillTypes.Contains(Player.SkillType.Archer) ||
                    _player.PossibleSkillTypes.Contains(Player.SkillType.Dagger)) {
                    return Attribute.Finesse;
                }

                return Attribute.Strength;
            } else {
                return spell.Scaling;
            }
        }

        #endregion

        #region Likelihood functions
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
            return Weighting(spells, spell => Gaussian(spell.Level - _player.Level, importance * LevelFactor));
        }

        private Pdf AttributeWeighting(IEnumerable<IConstSpell> spells, double importance) {
            var maxAttributeVal = _player.Attributes.Values.Max();
            return Weighting(spells, spell => {
                var scalingAttr = GetScalingAttribute(spell);
                if (scalingAttr != Attribute.None){
                    return Gaussian(_player.Attributes[scalingAttr] - maxAttributeVal, importance * AttributeFactor);
                }

                return NoWeightingLikelihood;
            });
        }

        private Pdf SkillPointsWeighting(IEnumerable<IConstSpell> spells, double importance) {
            int maxSkillVal = _player.SkillPoints.Values.Max();
            return Weighting(spells, spell => {
                if (spell.Benefit != Spell.School.None) {
                    return Gaussian(_player.SkillPoints[spell.Benefit] - maxSkillVal, importance * SkillPointFactor);
                }

                return NoWeightingLikelihood;
            });
        }

        //@TODO implementation
        private Pdf SkillTypeWeighting(IEnumerable<IConstSpell> spells, double importance) {
            var ret = spells.ToDictionary(spell => spell, _ => 1.0);
            return ret;
        }

        #endregion

        #region probabilistic stuff
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

        private Cdf GenerateCdf(Pdf pdf) {
            var ret = new Cdf();
            double accVal = 0;
            foreach (var (spell, prob) in pdf) {
                accVal += prob;
                ret.Add(ValueTuple.Create(accVal, spell));

            }

            return ret;
        }

        #endregion


        public IConstSpell[] GetSpells() {

            const int maxSkillPointDifference = 2;
            var allPossibleSpells = _matchConfig.CSpells.Where(spell => Learnable(spell, maxSkillPointDifference))
                .ToArray();
            var spellPdf = PdfProduct(new[] {
                LevelWeighting(allPossibleSpells, _matchConfig.SpellWeights.Level),
                AttributeWeighting(allPossibleSpells, _matchConfig.SpellWeights.Attribute),
                SkillPointsWeighting(allPossibleSpells, _matchConfig.SpellWeights.SkillPoints),
                SkillTypeWeighting(allPossibleSpells, 0.5)
            });

            var cdf = GenerateCdf(spellPdf);
            var numToGenerate = Math.Min(allPossibleSpells.Length, _numSpellsToGenerate);
            var ret = new IConstSpell[numToGenerate];
            var rng = new Random();
            for (int i = 0; i < numToGenerate; ++i) {
                var rn = rng.NextDouble();
                ret[i] = cdf.First(tuple => tuple.Item1 >= rn).Item2;
                spellPdf.Remove(ret[i]);
                Normalize(spellPdf);
                cdf = GenerateCdf(spellPdf);
            }

            return ret;
        }
    }
}
