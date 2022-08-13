using System.Collections.Generic;
using System.Collections.Immutable;
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

        public SpellListWrapper(IEnumerable<Spell> spells) {
            Spells = spells;
        }
    }


}
