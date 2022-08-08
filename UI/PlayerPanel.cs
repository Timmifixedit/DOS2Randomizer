using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DOS2Randomizer.DataStructures;

namespace DOS2Randomizer.UI {

    public partial class PlayerPanel : UserControl {

        private Player _player;

        public Player Player {
            get => _player;
            set {
                _player = value;
                if (_player != null) {
                    UnsubscribeFromControls();
                    RefreshUi();
                    SubscribeToControls();
                }
            }
        }

        private void SubscribeToControls() {
            playerName.OnValueChanged = value => {
                if (_player != null) {
                    _player.Name = value;
                }
            };
            playerLevel.OnValueChanged = value => {
                if (_player != null) {
                    _player.Level = value;
                }
            };
            attributePointsPanel1.OnValueChanged = value => {
                if (_player != null) {
                    _player.Attributes = value;
                }
            };
            skillPointsPanel1.OnValueChanged = value => {
                if (_player != null) {
                    _player.SkillPoints = value;
                }
            };
            possibleSkillTypes.OnValueChanged = value => {
                if (_player != null) {
                    _player.PossibleSkillTypes = value;
                }
            };
        }

        private void UnsubscribeFromControls() {
            playerName.OnValueChanged = null;
            playerLevel.OnValueChanged = null;
            attributePointsPanel1.OnValueChanged = null;
            skillPointsPanel1.OnValueChanged = null;
            possibleSkillTypes.OnValueChanged = null;
        }

        void RefreshUi() {
            playerName.Value = _player.Name;
            playerLevel.Value = _player.Level;
            attributePointsPanel1.Value = _player.Attributes;
            skillPointsPanel1.Value = _player.SkillPoints;
            possibleSkillTypes.Value = _player.PossibleSkillTypes;
            knownSpellList.Spells = _player.KnownSpells;
            equippedSpellList.Spells = _player.EquippedSpells;
        }

        public PlayerPanel() {
            InitializeComponent();
        }
    }
}
