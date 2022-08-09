using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace DOS2Randomizer.DataStructures {
    public class MatchConfig {
        public const int MaxNumPlayers = 4;
        public const int MaxLevel = 21;
        public string Name { get; set; }
        public int MaxNumMemSlots { get; set; }
        public int N { get; set; }
        public int K { get; set; }
        public OnLevelUp[] LevelSpecificEvents;
        public Spell[] Spells { get; set; }
        public Player[] Players { get; set; }

        public MatchConfig() {
            LevelSpecificEvents = Enumerable.Range(1, MaxLevel).Select(i => new OnLevelUp(i, 0, 0, 0)).ToArray();
            Name = "<Match config name>";
            Spells = Array.Empty<Spell>();
            Players = Array.Empty<Player>();
        }

        [JsonConstructor]
        public MatchConfig(string name, int maxNumMemSlots, int n, int k, OnLevelUp[] levelSpecificEvents,
            Spell[] spells, Player[] players) {
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
