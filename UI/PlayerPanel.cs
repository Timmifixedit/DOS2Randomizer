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
        public delegate void PlayerEvent(PlayerPanel player);

        private readonly Player _player;
        public PlayerEvent? OnRemoveClick;
        public PlayerEvent? OnDrawSpells;
        public PlayerEvent? OnConfigureSpells;
        public Player Player => _player;

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

        public void SetPlayerSpells(IEnumerable<Spell> spells) {
            _player.KnownSpells = spells.ToArray();
            _player.EquippedSpells = _player.KnownSpells.Intersect(_player.EquippedSpells).ToArray();
            RefreshUi();
        }

        private void RefreshUi() {
            UnsubscribeFromControls();
            UpdateUi();
            SubscribeToControls();
        }

        public PlayerPanel(Player player) {
            _player = player;
            InitializeComponent();
            RefreshUi();
        }

        private void remove_Click(object sender, EventArgs e) {
            OnRemoveClick?.Invoke(this);
        }

        private void configureSpells_Click(object sender, EventArgs e) {
            OnConfigureSpells?.Invoke(this);
        }

        private void drawSpells_Click(object sender, EventArgs e) {
            
        }
    }
}
