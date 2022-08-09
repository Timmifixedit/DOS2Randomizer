using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace DOS2Randomizer.DataStructures {

    public class Spell : IEquatable<Spell> {

        public enum School {
            Aero,
            Hydro,
            Pyro,
            Geo,
            Scoundrel,
            Warfare,
            Poly,
            Huntsman,
            Necro,
            Summoning
        }

        public enum Type {
            Util,
            Dmg,
            Cc,
            Heal,
            BuffDebuff
        }

        public Spell(string name, string imagePath) {
            Name = name;
            ImagePath = imagePath;
            Level = 1;
            Dependencies = Array.Empty<Spell>();
            SchoolRequirements = new Dictionary<School, int>(
                ((School[]) Enum.GetValues(typeof(School))).Select(school => new KeyValuePair<School, int>(school, 0)));
            Types = Array.Empty<Type>();
            Scaling = Attribute.None;
            MemorySlots = 1;
            LoadoutCost = 0;
            EquipmentRequirement = Player.SkillType.None;
        }

        [JsonConstructor]
        public Spell(string name, string imagePath, int level, Spell[] dependencies,
            Dictionary<School, int> schoolRequirements, Player.SkillType equipmentRequirement, Type[] types,
            Attribute scaling, int memorySlots, int loadoutCost) {
            Name = name;
            ImagePath = imagePath;
            Level = level;
            Dependencies = dependencies;
            SchoolRequirements = schoolRequirements;
            Types = types;
            Scaling = scaling;
            MemorySlots = memorySlots;
            LoadoutCost = loadoutCost;
            EquipmentRequirement = equipmentRequirement;
        }

        public string Name { get; set; }
        public string ImagePath { get; }
        public int Level { get; set; }
        public Spell[] Dependencies { get; set; }
        public Dictionary<School, int> SchoolRequirements { get; set; }
        public Player.SkillType EquipmentRequirement { get; set; }
        public Type[] Types { get; set; }
        public Attribute Scaling { get; set; }
        public int MemorySlots { get; set; }
        public int LoadoutCost { get; set; }

        public bool Equals(Spell? other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Name == other.Name && ImagePath == other.ImagePath && Level == other.Level &&
                   SequenceEqual(Types, other.Types) && Scaling == other.Scaling &&
                   MemorySlots == other.MemorySlots && LoadoutCost == other.LoadoutCost;
        }

        private static bool SequenceEqual<T>(IEnumerable<T>? lhs, IEnumerable<T>? rhs) {
            if (ReferenceEquals(lhs, rhs)) {
                return true;
            }

            if (rhs is null || lhs is null) {
                return false;
            }

            return lhs.SequenceEqual(rhs);
        }

        public override bool Equals(object? obj) {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Spell) obj);
        }

        public override int GetHashCode() {
            return HashCode.Combine(Name, ImagePath, Level, Types, (int) Scaling, MemorySlots, LoadoutCost);
        }

        public static bool operator ==(Spell? left, Spell? right) {
            return Equals(left, right);
        }

        public static bool operator !=(Spell? left, Spell? right) {
            return !Equals(left, right);
        }
    }
}
