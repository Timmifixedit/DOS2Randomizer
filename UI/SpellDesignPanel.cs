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
        private Spell[] _allSpells;
        public SpellDesignPanel() {
            InitializeComponent();
            typeSelection.Data = (Spell.Type[]) Enum.GetValues(typeof(Spell.Type));
            SubscribeToControls();
        }

        private void SubscribeToControls() {
            name.OnValueChanged = value => UpdateSpell();
            level.OnValueChanged = value => UpdateSpell();
            schoolBox.OnValueChanged = value => UpdateSpell();
            attributeBox.OnValueChanged = value => UpdateSpell();
            typeSelection.OnValueChanged = value => UpdateSpell();
            dependencies.OnValueChanged = value => UpdateSpell();
        }

        private void UnsubscribeFromControls() {
            level.OnValueChanged = null;
            name.OnValueChanged = null;
            schoolBox.OnValueChanged = null;
            attributeBox.OnValueChanged = null;
            typeSelection.OnValueChanged = null;
            dependencies.OnValueChanged = null;
        }

        private void UpdateSpell() {
            if (_spell is null) {
                return;
            }

            _spell.Level = level.Value;
            _spell.Name = name.Value;
            _spell.SchoolType = schoolBox.Value;
            _spell.Scaling = attributeBox.Value;
            _spell.Types = typeSelection.Value;
            _spell.Dependencies = dependencies.Value;
        }

        public Spell Spell {
            get => _spell;
            set {
                _spell = value;
                if (_spell != null) {
                    UnsubscribeFromControls();
                    RefreshUi();
                    SubscribeToControls();
                }
            }
        }

        public Spell[] AllSpells {
            get => _allSpells;
            set {
                _allSpells = value;
                dependencies.Data = _allSpells;
            }
        }

        private void RefreshUi() {
            name.Value = _spell.Name;
            level.Value = _spell.Level;
            schoolBox.Value = _spell.SchoolType;
            attributeBox.Value = _spell.Scaling;
            typeSelection.Value = _spell.Types;
            dependencies.Value = _spell.Dependencies;
        }
    }
}
