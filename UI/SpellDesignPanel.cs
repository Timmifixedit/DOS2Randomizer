using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DOS2Randomizer.DataStructures;

namespace DOS2Randomizer.UI {
    public partial class SpellDesignPanel : UserControl {
        private Spell _spell;
        public SpellDesignPanel() {
            InitializeComponent();
            name.OnValueChanged += value => UpdateSpell();
            level.OnValueChanged += value => UpdateSpell();
            schoolBox.OnValueChanged += value => UpdateSpell();
            attributeBox.OnValueChanged += value => UpdateSpell();
        }

        private void UpdateSpell() {
            if (_spell is null) {
                return;
            }

            _spell.Level = level.Value;
            _spell.Name = name.Value;
            _spell.SchoolType = schoolBox.Value;
            _spell.Scaling = attributeBox.Value;
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
            name.Value = _spell.Name;
            level.Value = _spell.Level;
            schoolBox.Value = _spell.SchoolType;
            attributeBox.Value = _spell.Scaling;
        }
    }
}
