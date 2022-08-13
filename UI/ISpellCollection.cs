using System;
using System.Collections.Generic;
using System.Text;
using DOS2Randomizer.DataStructures;

namespace DOS2Randomizer.UI {
    /// <summary>
    /// Interface for all classes that hold a collection of spells
    /// </summary>
    /// <typeparam name="T">type of spell</typeparam>
    public interface ISpellCollection<T> where T: IConstSpell{
        public IEnumerable<T>? Spells { get; set; }
    }
}
