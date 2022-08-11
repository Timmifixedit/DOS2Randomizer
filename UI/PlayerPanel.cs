﻿using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DOS2Randomizer.DataStructures;
using System.Linq;
using Attribute = DOS2Randomizer.DataStructures.Attribute;

namespace DOS2Randomizer.UI {

    public partial class PlayerPanel : UserControl {

        private readonly Player _player;
        private readonly IMatchProperties _matchConfig;
        public Action<Player>? OnRemoveClick;

        private void SubscribeToControls() {
            playerName.OnValueChanged = value => { _player.Name = value; };
            playerLevel.OnValueChanged = value => { _player.Level = value; };
            attributePointsPanel1.OnValueChanged = value => { _player.Attributes = value.ToImmutableDictionary(); };
            skillPointsPanel1.OnValueChanged = value => { _player.SkillPoints = value.ToImmutableDictionary(); };
            possibleSkillTypes.OnValueChanged = value => { _player.PossibleSkillTypes = value.ToImmutableArray(); };
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
            attributePointsPanel1.Value = new Dictionary<Attribute, int>(_player.Attributes);
            skillPointsPanel1.Value = new Dictionary<Spell.School, int>(_player.SkillPoints);
            possibleSkillTypes.Value = _player.PossibleSkillTypes;
            knownSpellList.Spells = _player.KnownSpells;
            equippedSpellList.Spells = _player.EquippedSpells;
        }

        private void SetPlayerSpells(IEnumerable<IConstSpell> spells) {
            _player.KnownSpells = spells.Cast<Spell>().ToImmutableArray();
            _player.EquippedSpells = _player.KnownSpells.Intersect(_player.EquippedSpells).ToImmutableArray();
            RefreshUi();
        }

        private void RefreshUi() {
            UnsubscribeFromControls();
            UpdateUi();
            SubscribeToControls();
        }

        public PlayerPanel(Player player, IMatchProperties matchConfig) {
            _player = player;
            _matchConfig = matchConfig;
            InitializeComponent();
            RefreshUi();
        }

        private void remove_Click(object sender, EventArgs e) {
            OnRemoveClick?.Invoke(_player);
        }

        private void configureSpells_Click(object sender, EventArgs e) {
            var spellChooseDialog =
                new SpellChooseDialog(_matchConfig.CSpells.Except(_player.CKnownSpells), _player.KnownSpells) {
                    FromListName = "Available Spells",
                    ToListName = "Known Spells",
                    OnConfirm = SetPlayerSpells,
                    Visible = true
                };
            spellChooseDialog.Activate();
        }

        private void drawSpells_Click(object sender, EventArgs e) {
            var level = _player.Level;
            if (_matchConfig.LevelSpecificEvents.Length < level) {
                throw new InvalidOperationException("not enough level specific entries");
            }

            var maxSpellsToThisLevel = _matchConfig.LevelSpecificEvents.Take(level).Select(data => data.NewSpells).Sum();
            var numSpellsKnown = _player.KnownSpells.Length;
            if (numSpellsKnown < maxSpellsToThisLevel) {
                var numSpellsToChoose = Math.Min(_matchConfig.K, maxSpellsToThisLevel - numSpellsKnown);
                var spellChooseDialog =
                    new ChooseKDialog(new Logic.SpellChooser(_matchConfig, _player), numSpellsToChoose, _player.NumRerolls) {
                        OnConfirm = spells => { SetPlayerSpells(_player.KnownSpells.Concat(spells.Cast<Spell>())); },
                        Visible = true
                    };
                spellChooseDialog.Activate();
            } else {
                MessageBox.Show(String.Format(Resources.Messages.MaxNumberSpellsReached, level));
            }
        }
    }
}
