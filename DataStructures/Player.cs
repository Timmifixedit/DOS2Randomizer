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

    public interface IConstPlayer {
        public string Name { get; }
        public int Level { get; }

        [JsonIgnore]
        public ImmutableArray<IConstSpell> CKnownSpells { get; }

        [JsonIgnore]
        public ImmutableArray<IConstSpell> CEquippedSpells { get; }
        public ImmutableArray<Player.SkillType> PossibleSkillTypes { get; }
        public ImmutableDictionary<Attribute, int> Attributes { get; }
        public ImmutableDictionary<Spell.School, int> SkillPoints { get; }
        public int NumRerolls { get; }
        public int NumShuffles { get; }
    }

    public class Player : IConstPlayer {
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
                new KeyValuePair<Attribute, int>(a, BaseAttributeValue))).ToImmutableDictionary();
            SkillPoints = new Dictionary<Spell.School, int>(
                ((Spell.School[])Enum.GetValues(typeof(Spell.School))).Select(s =>
                    new KeyValuePair<Spell.School, int>(s, 0))).ToImmutableDictionary();
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
        public ImmutableArray<IConstSpell> CKnownSpells => KnownSpells.CastArray<IConstSpell>();
        public ImmutableArray<Spell> EquippedSpells { get; set; }
        public ImmutableArray<IConstSpell> CEquippedSpells => EquippedSpells.CastArray<IConstSpell>();
        public ImmutableArray<SkillType> PossibleSkillTypes { get; set; }
        public ImmutableDictionary<Attribute, int> Attributes { get; set; }
        public ImmutableDictionary<Spell.School, int> SkillPoints { get; set; }
        public int NumRerolls { get; set; }
        public int NumShuffles { get; set; }

    }
}
