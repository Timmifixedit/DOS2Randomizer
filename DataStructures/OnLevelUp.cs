using Newtonsoft.Json;

namespace DOS2Randomizer.DataStructures {
    class OnLevelUp {

        [JsonConstructor]
        public OnLevelUp(int level, int newSpells, int newRerolls, int newShuffles) {
            Level = level;
            NewSpells = newSpells;
            NewRerolls = newRerolls;
            NewShuffles = newShuffles;
        }

        public int Level { get; }
        public int NewSpells { get; set; }
        public int NewRerolls { get; set; }
        public int NewShuffles { get; set; }
    }
}
