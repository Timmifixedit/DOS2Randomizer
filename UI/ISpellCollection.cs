using System;
using System.Collections.Generic;
using System.Text;
using DOS2Randomizer.DataStructures;

namespace DOS2Randomizer.UI {
    interface ISpellCollection {
        public Spell[]? Spells { get; set; }
    }
}
