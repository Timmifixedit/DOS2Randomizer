using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DOS2Randomizer.DataStructures;

namespace DOS2Randomizer.UI {
    public partial class SearchableSpellList : UserControl, ISplittableControl, ISpellCollection {
        public SearchableSpellList() {
            InitializeComponent();
            spellList.OnImageClick = spell => OnImageClick?.Invoke(spell);
        }

        public Spell[] Spells {
            get => search.AllSpells;
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

        public ImageClickEvent OnImageClick;
        public TableLayoutPanel LayoutPanel => layout;

        public Spell[] SpellCollection {
            get => Spells;
            set => Spells = value;
        }
    }
}
