using System.Collections.Immutable;
using Resources = DOS2Randomizer.Resources;
using Util = DOS2Randomizer.Util;
using DataStructures = DOS2Randomizer.DataStructures;
using School = DOS2Randomizer.DataStructures.Spell.School;
using Attribute = DOS2Randomizer.DataStructures.Attribute;

namespace SpellAttributeSwap {
    internal static class Program {
        private static void UpdateSpells(IEnumerable<DataStructures.Spell> spells,
            ImmutableDictionary<School, School> skillPermutation,
            ImmutableDictionary<Attribute, Attribute> attributePermutation) {
            foreach (var spell in spells) {
                spell.Scaling = attributePermutation[spell.Scaling];
                spell.Benefit = skillPermutation[spell.Benefit];
            }
        }

        private static void Save<T>(T config) where T : DataStructures.IConfig {
            using var fileChooser = new SaveFileDialog {AddExtension = true, DefaultExt = Resources.Misc.JsonExtension};
            if (fileChooser.ShowDialog() == DialogResult.OK) {
                Util.FileIo.SaveConfig(config, fileChooser.FileName);
            }
        }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            var skillPermutation = new Dictionary<School, School>(new KeyValuePair<School, School>[] {
                new(School.Aero, School.Aero), new(School.Geo, School.Hydro), new(School.Huntsman, School.Pyro),
                new(School.Hydro, School.Geo), new(School.Necro, School.Scoundrel), new(School.Poly, School.Warfare),
                new(School.Pyro, School.Poly), new(School.Scoundrel, School.Huntsman), new(School.Summoning, School.Necro),
                new(School.Warfare, School.Summoning), new(School.None, School.None)
            }).ToImmutableDictionary();

            var attributePermutation =
                new Dictionary<Attribute, Attribute>(new KeyValuePair<Attribute, Attribute>[] {
                        new(Attribute.Strength, Attribute.Strength), new(Attribute.Finesse, Attribute.Int),
                        new(Attribute.Int, Attribute.Finesse), new(Attribute.Con, Attribute.Con),
                        new(Attribute.Mem, Attribute.Mem), new(Attribute.Wit, Attribute.Wit),
                        new(Attribute.Weapon, Attribute.None), new(Attribute.None, Attribute.Weapon)
                    }).ToImmutableDictionary();
            using var fileChooser = new OpenFileDialog{Filter = Resources.Misc.JsonFilter};
            if (fileChooser.ShowDialog() != DialogResult.OK) {
                return;
            }

            if (Util.FileIo.ImportConfig<DataStructures.MatchConfig>(fileChooser.FileName) is { } matchConfig) {
                UpdateSpells(matchConfig.Spells, skillPermutation, attributePermutation);
                Util.ConfigUtils.OverwritePlayerSpells(matchConfig, matchConfig.Spells);
                Save(matchConfig);
            } else if (Util.FileIo.ImportConfig<DataStructures.SpellListWrapper>(fileChooser.FileName) is
                       { } spellConfig) {
                UpdateSpells(spellConfig.Spells, skillPermutation, attributePermutation);
                Save(spellConfig);
            }
        }
    }
}