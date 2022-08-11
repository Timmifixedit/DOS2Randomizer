using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace DOS2Randomizer.DataStructures {
    public interface IMatchProperties {
        public int MaxNumMemSlots { get; set; }
        public int N { get; }
        public int K { get; }
        public ImmutableArray<OnLevelUp> LevelSpecificEvents { get; }
        public ImmutableArray<Spell> Spells { get; }
    }

    public interface IConstMatchConfig : IMatchProperties {
        public string Name { get;}
        public ImmutableArray<Player> Players { get; set; }

    }

    public class MatchConfig : IConstMatchConfig {
        public const int MaxNumPlayers = 4;
        public const int MaxLevel = 21;
        public string Name { get; set; }
        public int MaxNumMemSlots { get; set; }
        public int N { get; set; }
        public int K { get; set; }
        public ImmutableArray<OnLevelUp> LevelSpecificEvents { get; set; }
        public ImmutableArray<Spell> Spells { get; set; }
        public ImmutableArray<Player> Players { get; set; }

        public MatchConfig() {
            LevelSpecificEvents =
                Enumerable.Range(1, MaxLevel).Select(i => new OnLevelUp(i, 0, 0, 0)).ToImmutableArray();
            Name = "<Match config name>";
            Spells = ImmutableArray<Spell>.Empty;
            Players = ImmutableArray<Player>.Empty;
        }

        [JsonConstructor]
        public MatchConfig(string name, int maxNumMemSlots, int n, int k, ImmutableArray<OnLevelUp> levelSpecificEvents,
            ImmutableArray<Spell> spells, ImmutableArray<Player> players) {
            Name = name;
            MaxNumMemSlots = maxNumMemSlots;
            N = n;
            K = k;
            LevelSpecificEvents = levelSpecificEvents;
            Spells = spells;
            Players = players;
        }
    }
}
