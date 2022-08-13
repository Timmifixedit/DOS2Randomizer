using System.Collections.Generic;
using System.Collections.Immutable;
using Newtonsoft.Json;

namespace DOS2Randomizer.DataStructures {
    interface ISerilizable { }
    public record OnLevelUp(int Level, int NewSpells, int NewRerolls, int NewShuffles);
    public class MatchConfigGuard {
        private readonly MatchConfig _matchConfig;

        public MatchConfigGuard(MatchConfig matchConfig) {
            _matchConfig = matchConfig;
        }

        public void Save(string filename) {
            Util.FileIo.SaveConfig(_matchConfig, filename);
        }

        public IConstMatchConfig Get => _matchConfig;
    }

    public class SpellListWrapper : ISerilizable {
        public IEnumerable<Spell> Spells { get; }

        public SpellListWrapper(IEnumerable<Spell> spells) {
            Spells = spells;
        }
    }


}
