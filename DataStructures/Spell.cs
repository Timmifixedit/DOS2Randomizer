using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace DOS2Randomizer.DataStructures {

    public class Spell {

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
        }
        
        [JsonConstructor]
        public Spell(string name, string imagePath, int level, Spell[] dependencies, School schoolType, Type[] types,
            Attribute scaling, int memorySlots) {
            Name = name;
            ImagePath = imagePath;
            Level = level;
            Dependencies = dependencies;
            SchoolType = schoolType;
            Types = types;
            Scaling = scaling;
            MemorySlots = memorySlots;
        }

        public string Name { get; set; }
        public string ImagePath { get; }
        public int Level { get; set; }
        public Spell[] Dependencies { get; set; }
        public School SchoolType { get; set; }
        public Type[] Types { get; set; }
        public Attribute Scaling { get; set; }
        public int MemorySlots { get; set; }
    }
}
