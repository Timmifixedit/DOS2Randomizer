using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DOS2Randomizer.DataStructures {
    public class Spell {

        public Spell(string name, string imagePath) {
            Name = name;
            ImagePath = imagePath;
        }
        public string Name { get; }
        public string ImagePath { get; }

        // @TODO
    }
}
