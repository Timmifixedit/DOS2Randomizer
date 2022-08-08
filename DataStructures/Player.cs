using System.Collections.Generic;
using Newtonsoft.Json;

namespace DOS2Randomizer.DataStructures {
    public enum Attribute {
        Strength,
        Int,
        Finesse,
        Con,
        Mem,
        Wit,
        None
    }

    public class Player {
        public enum SkillType {
            Melee,
            Archer,
            Shield,
            Dagger,
            None
        }

        public Player() {
            Name = "";
            Level = 1;
        }

        [JsonConstructor]
        public Player(string name, int level, Spell[] knownSpells, Spell[] equippedSpells,
            SkillType[] possibleSkillTypes, Dictionary<Attribute, int> attributes,
            Dictionary<Spell.School, int> skillPoints) {
            Name = name;
            Level = level;
            KnownSpells = knownSpells;
            EquippedSpells = equippedSpells;
            PossibleSkillTypes = possibleSkillTypes;
            Attributes = attributes;
            SkillPoints = skillPoints;
        }

        public string Name { get; set; }
        public int Level { get; set; }
        public Spell[] KnownSpells { get; set; }
        public Spell[] EquippedSpells { get; set; }
        public SkillType[] PossibleSkillTypes { get; set; }
        public Dictionary<Attribute, int> Attributes;
        public Dictionary<Spell.School, int> SkillPoints;
    }
}
