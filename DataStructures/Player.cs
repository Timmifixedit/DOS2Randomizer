using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
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
        public const int BaseAttributeValue = 10;
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
            KnownSpells = ImmutableArray<Spell>.Empty;
            EquippedSpells = ImmutableArray<Spell>.Empty;
            PossibleSkillTypes = ImmutableArray<SkillType>.Empty;
            Attributes = new Dictionary<Attribute, int>(((Attribute[])Enum.GetValues(typeof(Spell.School))).Select(a =>
                new KeyValuePair<Attribute, int>(a, 0))).ToImmutableDictionary();
            SkillPoints = new Dictionary<Spell.School, int>(
                ((Spell.School[])Enum.GetValues(typeof(Spell.School))).Select(s =>
                    new KeyValuePair<Spell.School, int>(s, BaseAttributeValue))).ToImmutableDictionary();
        }

        [JsonConstructor]
        public Player(string name, int level, ImmutableArray<Spell> knownSpells, ImmutableArray<Spell> equippedSpells,
            ImmutableArray<SkillType> possibleSkillTypes, ImmutableDictionary<Attribute, int> attributes,
            ImmutableDictionary<Spell.School, int> skillPoints, int numRerolls, int numShuffles) {
            Name = name;
            Level = level;
            KnownSpells = knownSpells;
            EquippedSpells = equippedSpells;
            PossibleSkillTypes = possibleSkillTypes;
            Attributes = attributes;
            SkillPoints = skillPoints;
            NumRerolls = numRerolls;
            NumShuffles = numShuffles;
        }

        public string Name { get; set; }
        public int Level { get; set; }
        public ImmutableArray<Spell> KnownSpells { get; set; }
        public ImmutableArray<Spell> EquippedSpells { get; set; }
        public ImmutableArray<SkillType> PossibleSkillTypes { get; set; }
        public ImmutableDictionary<Attribute, int> Attributes;
        public ImmutableDictionary<Spell.School, int> SkillPoints;
        public int NumRerolls { get; set; }
        public int NumShuffles { get; set; }

    }
}
