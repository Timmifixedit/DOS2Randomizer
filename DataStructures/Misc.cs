using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace DOS2Randomizer.DataStructures {
    /// <summary>
    /// This interface is used to mark classes as serializable configs and provide additional utilities
    /// </summary>
    public interface IConfig {

        /// <summary>
        /// Checks if all spells are valid, i.e. have a valid icon
        /// </summary>
        /// <param name="missingFiles">string containing an error message and a list of missing file names</param>
        /// <returns>true if all spells are valid, false otherwise</returns>
        bool Valid(out string? missingFiles);

        /// <summary>
        /// Migrates all contained spells to the current machine
        /// </summary>
        /// <param name="imageDirectory">directory path where to look for spell icons</param>
        /// <returns>migrated config, or null if failed</returns>
        IConfig? Migrate(string imageDirectory);
    }

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
    public class SpellListWrapper : IConfig {
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
        }

        public bool Valid(out string? missingFiles) {
            if (MissingIcons(Spells) is { Length: > 0 } missing) {
                missingFiles = missing;
                return false;
            }

            missingFiles = null;
            return true;
        }

        public IConfig? Migrate(string imageDirectory) {
           return Util.ConfigUtils.MigrateSpellConfig(this, imageDirectory);
        }
    }
}
