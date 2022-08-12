using System;
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
using DOS2Randomizer.Logic;
using Attribute = DOS2Randomizer.DataStructures.Attribute;

namespace DOS2Randomizer.UI {

    public partial class PlayerPanel : UserControl {

        private readonly IMutablePlayer _player;
        private readonly IMatchProperties _matchConfig;
        public Action<IMutablePlayer>? OnRemoveClick;

        private void SubscribeToControls() {
            playerName.OnValueChanged = value => { _player.Name = value; };
            playerLevel.OnValueChanged = SetPlayerLevel;
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
            knownSpellList.Spells = _player.CKnownSpells;
            equippedSpellList.Spells = _player.CEquippedSpells;
            shuffle.Text = String.Format(Resources.Messages.Shuffle, _player.NumShuffles);
            shuffle.Enabled = _player.NumShuffles > 0;
        }

        private void SetPlayerSpells(IEnumerable<IConstSpell> spells) {
            _player.CKnownSpells = spells.ToImmutableArray();
            _player.CEquippedSpells = _player.CKnownSpells.Intersect(_player.CEquippedSpells).ToImmutableArray();
            RefreshUi();
        }

        private void RefreshUi() {
            UnsubscribeFromControls();
            UpdateUi();
            SubscribeToControls();
        }

        public PlayerPanel(IMutablePlayer player, IMatchProperties matchConfig) {
            _player = player;
            _matchConfig = matchConfig;
            InitializeComponent();
            playerLevel.Max = MatchConfig.MaxLevel;
            knownSpellList.OnImageClick = EquipSpell;
            RefreshUi();
        }

        private void EquipSpell(IConstSpell spell) {
            if (_player.CEquippedSpells.Contains(spell)) {
                MessageBox.Show(String.Format(Resources.Messages.AlreadyEquipped, spell.Name));
                return;
            }

            var slotsLeft = _player.NumMemSlots - _player.CEquippedSpells.Select(s => s.MemorySlots).Sum();
            if (spell.MemorySlots > slotsLeft) {
                MessageBox.Show(string.Format(Resources.Messages.TooFewMemSlots, _player.Name, slotsLeft, spell.Name,
                    spell.MemorySlots));
            } else {
                if (MessageBox.Show(String.Format(Resources.Messages.EquipSpell, spell.Name), "",
                        MessageBoxButtons.YesNo) == DialogResult.Yes) {
                    _player.CEquippedSpells = _player.CEquippedSpells.Add(spell);
                    equippedSpellList.Spells = _player.CEquippedSpells;
                }
            }
        }

        public void SetPlayerLevel(int level) {
            if (level <= MatchConfig.MaxLevel) {
                if (level > _matchConfig.LevelSpecificEvents.Length) {
                    throw new InvalidOperationException("not enough level specific entries");
                }

                if (level > _player.Level) {
                    var levelUpdates = _matchConfig.LevelSpecificEvents[level - 1];
                    _player.NumRerolls += levelUpdates.NewRerolls;
                    _player.NumShuffles += levelUpdates.NewShuffles;
                }

                _player.Level = level;
                RefreshUi();
            }
        }

        private void remove_Click(object sender, EventArgs e) {
            OnRemoveClick?.Invoke(_player);
        }

        private void configureSpells_Click(object sender, EventArgs e) {
            var spellChooseDialog =
                new SpellChooseDialog(_matchConfig.CSpells.Except(_player.CKnownSpells), _player.CKnownSpells) {
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
            var numSpellsKnown = _player.CKnownSpells.Length;
            if (numSpellsKnown < maxSpellsToThisLevel) {
                var numSpellsToChoose = Math.Min(_matchConfig.K, maxSpellsToThisLevel - numSpellsKnown);
                var spellChooseDialog =
                    new ChooseKDialog(new Logic.SpellChooser(_matchConfig, _player), numSpellsToChoose, _player.NumRerolls) {
                        OnConfirm = (spells, numRerolls) => {
                            _player.NumRerolls = numRerolls;
                            SetPlayerSpells(_player.CKnownSpells.Concat(spells.Cast<Spell>()));
                        },
                        Visible = true
                    };
                spellChooseDialog.Activate();
            } else {
                MessageBox.Show(String.Format(Resources.Messages.MaxNumberSpellsReached, level));
            }
        }

        private void shuffle_Click(object sender, EventArgs e) {
            if (_player.NumShuffles <= 0) {
                MessageBox.Show(Resources.Messages.NoShuffles);
            } else if (_player.CKnownSpells.Length <= _player.NumMemSlots) {
                MessageBox.Show(String.Format(Resources.Messages.ShuffleNoEffect, _player.Name, _player.NumMemSlots,
                    _player.CKnownSpells.Length));
            } else {
                --_player.NumShuffles;
                //@TODO this may choose a set of spells that violates spell dependencies or memory constraints
                _player.CEquippedSpells = _player.CKnownSpells.ChooseRandom(_player.NumMemSlots).ToImmutableArray();
                RefreshUi();
            }
        }
    }
}
