using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DOS2Randomizer.DataStructures;
using Attribute = DOS2Randomizer.DataStructures.Attribute;

namespace DOS2Randomizer.UI {
    public partial class SpellDesignPanel : UserControl {
        private Spell _spell;
        public SpellDesignPanel() {
            InitializeComponent();
        }

        public Spell Spell {
            get => _spell;
            set {
                _spell = value;
                if (_spell != null) {
                    RefreshUi();
                }
            }
        }

        private void RefreshUi() {

        }
    }
}
