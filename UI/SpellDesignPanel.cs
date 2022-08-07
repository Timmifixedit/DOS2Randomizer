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
            search.OnValueChanged += value => { dependencies.Value = _spell?.Dependencies; };
            SubscribeToControls();
        }

        private void SubscribeToControls() {
            name.OnValueChanged = value => {
                if (_spell != null) {
                    _spell.Name = value;
                }    
            };
            level.OnValueChanged = value => {
                if (_spell != null) {
                    _spell.Level = value;
                }
            };
            skillPointsPanel1.OnValueChanged = value => {
                if (_spell != null) {
                    _spell.SchoolRequirements = value;
                }
            };
            attributeBox.OnValueChanged = value => {
                if (_spell != null) {
                    _spell.Scaling= value;
                }
            };
            typeSelection.OnValueChanged = value => {
                if (_spell != null) {
                    _spell.Types = value;
                }
            };
            dependencies.OnValueChanged = value => {
                if (_spell != null) {
                    var removed = dependencies.Data.Except(value);
                    _spell.Dependencies = (_spell.Dependencies ?? new Spell[0]).Except(removed).Union(value).ToArray();
                }
            };
            memSlots.OnValueChanged = value => {
                if (_spell != null) {
                    _spell.MemorySlots = value;
                }
            };
            cost.OnValueChanged = value => {
                if (_spell != null) {
                    _spell.LoadoutCost = value;
                }
            };
        }

        private void UnsubscribeFromControls() {
            level.OnValueChanged = null;
            name.OnValueChanged = null;
            skillPointsPanel1.OnValueChanged = null;
            attributeBox.OnValueChanged = null;
            typeSelection.OnValueChanged = null;
            dependencies.OnValueChanged = null;
            memSlots.OnValueChanged = null;
            cost.OnValueChanged = null;
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
                search.AllSpells = _allSpells;
            }
        }

        private void RefreshUi() {
            try {
                name.Value = _spell.Name;
                level.Value = _spell.Level;
                skillPointsPanel1.Value = _spell.SchoolRequirements;
                attributeBox.Value = _spell.Scaling;
                typeSelection.Value = _spell.Types;
                dependencies.Value = _spell.Dependencies;
                memSlots.Value = _spell.MemorySlots;
                cost.Value = _spell.LoadoutCost;
            } catch (ArgumentException e) {
                MessageBox.Show(Resources.ErrorMessages.InvalidConfigValues + e.Message);
            }
        }
    }
}
