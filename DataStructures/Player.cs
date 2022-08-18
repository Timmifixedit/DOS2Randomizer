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
        None,
        Weapon
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

        [JsonIgnore]
        public int NumMemSlots { get; }

        [JsonIgnore]
        public int NumMemorySlotsUsed { get; }

        public int NumRerollsExpended { get; }
        public int NumShufflesExpended { get; }
        public Player.WeaponDmgType DmgType { get; }
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
        public new int NumRerollsExpended { get; set; }
        public new int NumShufflesExpended { get; set; }
        public new Player.WeaponDmgType DmgType { get; set; }

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

        public enum WeaponDmgType {
            Physical,
            Magical
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
            Attributes = new Dictionary<Attribute, int>(((Attribute[])Enum.GetValues(typeof(Attribute)))
                .Where(a => a is not (Attribute.None or Attribute.Weapon))
                .Select(a => new KeyValuePair<Attribute, int>(a, BaseAttributeValue))).ToImmutableDictionary();
            SkillPoints = new Dictionary<Spell.School, int>(
                ((Spell.School[])Enum.GetValues(typeof(Spell.School)))
                .Where(s => s is not Spell.School.None)
                .Select(s => new KeyValuePair<Spell.School, int>(s, 0))).ToImmutableDictionary();
            DmgType = WeaponDmgType.Physical;
        }

        [JsonConstructor]
        public Player(string name, int level, ImmutableArray<Spell> knownSpells, ImmutableArray<Spell> equippedSpells,
            ImmutableArray<SkillType> possibleSkillTypes, ImmutableDictionary<Attribute, int> attributes,
            ImmutableDictionary<Spell.School, int> skillPoints, int numRerollsExpended, int numShufflesExpended,
            WeaponDmgType weaponDmgType) {
            Name = name;
            Level = level;
            KnownSpells = knownSpells;
            EquippedSpells = equippedSpells;
            PossibleSkillTypes = possibleSkillTypes;
            Attributes = attributes;
            SkillPoints = skillPoints;
            NumRerollsExpended = numRerollsExpended;
            NumShufflesExpended = numShufflesExpended;
            DmgType = weaponDmgType;
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
        public int NumMemSlots => MemSlotsAtLevel(Level, Attributes[Attribute.Mem]);
        public int NumMemorySlotsUsed => CEquippedSpells.Select(spell => spell.MemorySlots).Sum();
        public int NumRerollsExpended { get; set; }
        public int NumShufflesExpended { get; set; }
        public WeaponDmgType DmgType { get; set; }

        public static int MemSlotsAtLevel(int playerLevel, int memory) =>
            memory - BaseAttributeValue + (playerLevel / 2) + BaseMemSlots;
    }
}
