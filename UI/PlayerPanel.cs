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
        private readonly Spell[] _allSpells;
        public Action? OnRemoveClick;

        private void SubscribeToControls() {
            playerName.OnValueChanged = value => { _player.Name = value; };
            playerLevel.OnValueChanged = value => { _player.Level = value; };
            attributePointsPanel1.OnValueChanged = value => { _player.Attributes = value; };
            skillPointsPanel1.OnValueChanged = value => { _player.SkillPoints = value; };
            possibleSkillTypes.OnValueChanged = value => { _player.PossibleSkillTypes = value.ToArray(); };
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
            _allSpells = allSpells;
            InitializeComponent();
            RefreshUi();
        }

        private void remove_Click(object sender, EventArgs e) {
            OnRemoveClick?.Invoke();
        }

        private void configureSpells_Click(object sender, EventArgs e) {
            var spellChooseDialog = new SpellChooseDialog(_allSpells.Except(_player.KnownSpells), _player.KnownSpells) {
                OnConfirm = selected => {
                    _player.KnownSpells = selected.ToArray();
                    RefreshUi();
                },
                Visible = true
            };
            spellChooseDialog.Activate();
        }
    }
}
