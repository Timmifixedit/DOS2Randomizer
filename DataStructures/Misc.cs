using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace DOS2Randomizer.DataStructures {
    /// <summary>
    /// This tag is used to mark classes as serializable
    /// </summary>
    interface ISerilizable { }
    public record OnLevelUp(int Level, int NewSpells, int NewRerolls, int NewShuffles);

    /// <summary>
    /// Wrapper for MatchConfig that only exposes a const view, but makes sure all fields are serialized properly
    /// </summary>
    public class MatchConfigGuard {
        private readonly MatchConfig _matchConfig;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="matchConfig">MatchConfig to guard</param>
        public MatchConfigGuard(MatchConfig matchConfig) {
            _matchConfig = matchConfig;
        }

        /// <summary>
        /// Saves the config as Json
        /// </summary>
        /// <param name="filename">destination file</param>
        public void Save(string filename) {
            Util.FileIo.SaveConfig(_matchConfig, filename);
        }

        /// <summary>
        /// Readonly view of internal config
        /// </summary>
        public IConstMatchConfig Get => _matchConfig;
    }

    /// <summary>
    /// Serializable wrapper for a list of spells
    /// </summary>
    public class SpellListWrapper : ISerilizable {
        public IEnumerable<Spell> Spells { get; }

        /// <summary>
        /// Generates a string containing the names and icon paths of all spells where the icon could not be found
        /// </summary>
        /// <param name="spells"></param>
        /// <returns>string containing the names and icon paths of all spells where the icon could not be found</returns>
        public static string MissingIcons(IEnumerable<Spell> spells) {
            var ret = new StringBuilder();
            foreach (var missing in spells.Where(spell => !File.Exists(spell.ImagePath))) {
                ret.AppendLine($"{missing.Name} ('{missing.ImagePath}')");
            }

            return ret.ToString();
        }

        public SpellListWrapper(IEnumerable<Spell> spells) {
            Spells = spells.ToArray();
            var missingIcons = MissingIcons(Spells);
            if (missingIcons.Length > 0) {
                throw new FileNotFoundException(
                    "Invalid Spells config. Could not find icon for the following spells" + Environment.NewLine +
                    missingIcons);
            }
        }
    }


}
