using System;
using System.Collections.Generic;
using System.Text;
using DOS2Randomizer.DataStructures;

namespace DOS2Randomizer.UI {
    public interface ISpellCollection<T> where T: IConstSpell{
        public IEnumerable<T>? Spells { get; set; }
    }
}
