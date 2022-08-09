using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DOS2Randomizer.DataStructures;
using System.Linq;

namespace DOS2Randomizer.UI {

    public partial class PlayerPanel : UserControl {

        private readonly Player _player;
        private readonly Spell[] _spells;
        public Action? OnRemoveClick;

        private void SubscribeToControls() {
            playerName.OnValueChanged = value => { _player.Name = value; };
            playerLevel.OnValueChanged = value => { _player.Level = value; };
            attributePointsPanel1.OnValueChanged = value => { _player.Attributes = value; };
            skillPointsPanel1.OnValueChanged = value => { _player.SkillPoints = value; };
            possibleSkillTypes.OnValueChanged = value => { _player.PossibleSkillTypes = value; };
        }

        private void UnsubscribeFromControls() {
            playerName.OnValueChanged = null;
            playerLevel.OnValueChanged = null;
            attributePointsPanel1.OnValueChanged = null;
            skillPointsPanel1.OnValueChanged = null;
            possibleSkillTypes.OnValueChanged = null;
        }

        void UpdateUi() {
            playerName.Value = _player.Name;
            playerLevel.Value = _player.Level;
            attributePointsPanel1.Value = _player.Attributes;
            skillPointsPanel1.Value = _player.SkillPoints;
            possibleSkillTypes.Value = _player.PossibleSkillTypes;
            knownSpellList.Spells = _player.KnownSpells;
            equippedSpellList.Spells = _player.EquippedSpells;
        }

        private void RefreshUi() {
            UnsubscribeFromControls();
            UpdateUi();
            SubscribeToControls();
        }

        public PlayerPanel(Player player, Spell[] allSpells) {
            _player = player;
            _spells = allSpells;
            InitializeComponent();
            RefreshUi();
        }

        private void remove_Click(object sender, EventArgs e) {
            OnRemoveClick?.Invoke();
        }

        private void addSpells_Click(object sender, EventArgs e) {
            var spellChooseDialog = new SpellChooseDialog(_spells) {
                OnConfirm = value => {
                    _player.KnownSpells = _player.KnownSpells.Concat(value).Distinct().ToArray();
                    UnsubscribeFromControls();
                    UpdateUi();
                    SubscribeToControls();
                },
                Visible = true
            };
            spellChooseDialog.Activate();
        }
    }
}
