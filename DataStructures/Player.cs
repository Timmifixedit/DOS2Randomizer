using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Newtonsoft.Json;

namespace DOS2Randomizer.DataStructures {
    /// <summary>
    /// Primary player attributes
    /// </summary>
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

        [JsonIgnore]
        public int NumMemSlots { get; }

        [JsonIgnore]
        public int NumMemorySlotsUsed { get; }
    }

    public interface IMutablePlayer : IConstPlayer {
        public new string Name { get; set; }
        public new int Level { get; set; }

        [JsonIgnore]
        public new ImmutableArray<IConstSpell> CKnownSpells { get; set; }

        [JsonIgnore]
        public new ImmutableArray<IConstSpell> CEquippedSpells { get; set; }
        public new ImmutableArray<Player.SkillType> PossibleSkillTypes { get; set; }
        public new ImmutableDictionary<Attribute, int> Attributes { get; set; }
        public new ImmutableDictionary<Spell.School, int> SkillPoints { get; set; }
        public new int NumRerolls { get; set; }
        public new int NumShuffles { get; set; }
    }

    /// <summary>
    /// Player class
    /// </summary>
    public class Player : IMutablePlayer {
        public const int BaseAttributeValue = 10;
        public const int BaseMemSlots = 3;

        /// <summary>
        /// Type of skills usable by player
        /// </summary>
        public enum SkillType {
            Melee,
            Archer,
            Shield,
            Dagger,
            None
        }

        /// <summary>
        /// Creates a level 1 empty player object, initializes all members
        /// </summary>
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

        public ImmutableArray<IConstSpell> CKnownSpells {
            get => KnownSpells.CastArray<IConstSpell>();
            set => KnownSpells = value.Cast<Spell>().ToImmutableArray();
        }
        public ImmutableArray<Spell> EquippedSpells { get; set; }

        public ImmutableArray<IConstSpell> CEquippedSpells {
            get => EquippedSpells.CastArray<IConstSpell>();
            set => EquippedSpells = value.Cast<Spell>().ToImmutableArray();
        }
        public ImmutableArray<SkillType> PossibleSkillTypes { get; set; }
        public ImmutableDictionary<Attribute, int> Attributes { get; set; }
        public ImmutableDictionary<Spell.School, int> SkillPoints { get; set; }
        public int NumRerolls { get; set; }
        public int NumShuffles { get; set; }
        public int NumMemSlots => Attributes[Attribute.Mem] - BaseAttributeValue + (Level / 2) + BaseMemSlots;
        public int NumMemorySlotsUsed => CEquippedSpells.Select(spell => spell.MemorySlots).Sum();
    }
}
