using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DOS2Randomizer.DataStructures;

namespace DOS2Randomizer.UI {

    /// <summary>
    /// Spell list with additional search function
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public partial class SearchableSpellListBase<T> : UserControl, ISplittableControl, ISpellCollection<T> where T: IConstSpell{
        public SearchableSpellListBase() {
            InitializeComponent();
            spellList.OnImageClick = spell => OnImageClick?.Invoke(spell);
        }

        public IEnumerable<T>? Spells {
            get => search.AllSpells ?? Array.Empty<T>();
            set => search.AllSpells = value;
        }

        public int SplitPercentage {
            get => (this as ISplittableControl).SplitPercentageImpl;
            set => (this as ISplittableControl).SplitPercentageImpl = value;
        }

        public string Label {
            get => label.Text;
            set => label.Text = value;
        }

        /// <summary>
        /// Event that is triggered when a spell in the list is selected
        /// </summary>
        public Action<T>? OnImageClick;
        public TableLayoutPanel LayoutPanel => layout;
    }

    public class SearchableSpellList : SearchableSpellListBase<Spell> {}
    public class CSearchableSpellList : SearchableSpellListBase<IConstSpell> {}
}
