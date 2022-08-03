using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

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
            Heal
        }

        public Spell(string name, string imagePath) {
            Name = name;
            ImagePath = imagePath;
            Level = 1;
        }

        public string Name { get; set; }
        public string ImagePath { get; }
        public int Level { get; set; }
        public Spell[] Dependencies { get; set; }
        public School SchoolType { get; set; }
        public Type[] Types { get; set; }
        public Attribute Scaling { get; set; }


        // @TODO
    }
}
