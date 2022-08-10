using System;
using System.Collections.Generic;
using System.Text;
using DOS2Randomizer.DataStructures;

namespace DOS2Randomizer.UI {
    public interface ISpellCollection {
        public IEnumerable<Spell>? Spells { get; set; }
    }
}
