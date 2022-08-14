using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Windows.Forms;
using DOS2Randomizer.DataStructures;
using System.Linq;
using DOS2Randomizer.Logic;
using Attribute = DOS2Randomizer.DataStructures.Attribute;

namespace DOS2Randomizer.UI {

    /// <summary>
    /// User control that manages a player
    /// </summary>
    public partial class PlayerPanel : UserControl {

        #region fields

        private readonly IMutablePlayer _player;
        private readonly IMatchProperties _matchConfig;
        public Action<IMutablePlayer>? OnRemoveClick;

        #endregion

        #region properties

        private int NumRerolls => Math.Max(GetAccumulatedLevelInfo().NewRerolls - _player.NumRerollsExpended, 0);
        private int NumShuffles => Math.Max(GetAccumulatedLevelInfo().NewShuffles - _player.NumShufflesExpended, 0);
        private int NumSpells => GetAccumulatedLevelInfo().NewSpells;

        #endregion

        #region Ui
        private void SubscribeToControls() {
            playerName.OnValueChanged = value => { _player.Name = value; };
            playerLevel.OnValueChanged = SetPlayerLevel;
            attributePointsPanel1.OnValueChanged = value => {
                _player.Attributes = value.ToImmutableDictionary();
                RefreshUi();
            };
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
            equippedSpellList.Label = String.Format(Resources.Messages.EquippedSpellsAndMem, _player.NumMemorySlotsUsed,
                _player.NumMemSlots);
            shuffle.Text = String.Format(Resources.Messages.Shuffle, NumShuffles);
            shuffle.Enabled = NumShuffles > 0;
        }
        private void RefreshUi() {
            UnsubscribeFromControls();
            UpdateUi();
            SubscribeToControls();
        }


        #endregion

        public PlayerPanel(IMutablePlayer player, IMatchProperties matchConfig) {
            _player = player;
            _matchConfig = matchConfig;
            InitializeComponent();
            playerLevel.Max = MatchConfig.MaxLevel;
            knownSpellList.OnImageClick = EquipSpell;
            if (_matchConfig.LevelSpecificEvents.Length != MatchConfig.MaxLevel) {
                throw new ArgumentException("Expected MatchConfig to have a level specific entry for each level");
            }

            RefreshUi();
        }

        #region helpers

        private OnLevelUp GetAccumulatedLevelInfo() {
            var levelRange = _matchConfig.LevelSpecificEvents.Take(_player.Level).ToArray();
            return new OnLevelUp(_player.Level, levelRange.Select(info => info.NewSpells).Sum(),
                levelRange.Select(info => info.NewRerolls).Sum(),
                levelRange.Select(info => info.NewShuffles).Sum());
        }

        private void SetEquippedSpells(IEnumerable<IConstSpell> spells) {
            _player.CEquippedSpells = spells.ToImmutableArray();
            equippedSpellList.Spells = _player.CEquippedSpells;
            RefreshUi();
        }

        private void SetPlayerSpells(IEnumerable<IConstSpell> spells) {
            _player.CKnownSpells = spells.ToImmutableArray();
            knownSpellList.Spells = _player.CKnownSpells;
            SetEquippedSpells(_player.CKnownSpells.Intersect(_player.CEquippedSpells).ToImmutableArray());
        }


        private void EquipSpell(IConstSpell spell) {
            if (_player.CEquippedSpells.Contains(spell)) {
                MessageBox.Show(String.Format(Resources.Messages.AlreadyEquipped, spell.Name));
                return;
            }

            var slotsLeft = _player.NumMemSlots - _player.NumMemorySlotsUsed;
            if (spell.MemorySlots > slotsLeft) {
                MessageBox.Show(string.Format(Resources.Messages.TooFewMemSlots, _player.Name, slotsLeft, spell.Name,
                    spell.MemorySlots));
            } else {
                if (MessageBox.Show(String.Format(Resources.Messages.EquipSpell, spell.Name), "",
                        MessageBoxButtons.YesNo) == DialogResult.Yes) {
                    SetEquippedSpells(_player.CEquippedSpells.Add(spell));
                }
            }
        }

        private void SetPlayerLevel(int level) {
            if (level <= MatchConfig.MaxLevel) {
                _player.Level = level;
                RefreshUi();
            }
        }

        #endregion

        #region event handlers
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
                    new ChooseKDialog(new Logic.SpellChooser(_matchConfig, _player), numSpellsToChoose, NumRerolls) {
                        OnConfirm = (spells, numRerolls) => {
                            _player.NumRerollsExpended += NumRerolls - numRerolls;
                            SetPlayerSpells(_player.CKnownSpells.Concat(spells));
                        },
                        Visible = true
                    };
                spellChooseDialog.Activate();
            } else {
                MessageBox.Show(String.Format(Resources.Messages.MaxNumberSpellsReached, level));
            }
        }

        private void shuffle_Click(object sender, EventArgs e) {
            if (NumShuffles <= 0) {
                MessageBox.Show(Resources.Messages.NoShuffles);
                return;
            }

            var requiredSlots = _player.CKnownSpells.Select(spell => spell.MemorySlots).Sum();
            if (requiredSlots <= _player.NumMemSlots) {
                MessageBox.Show(String.Format(Resources.Messages.ShuffleNoEffect, _player.Name, _player.NumMemSlots,
                    requiredSlots));
            } else {
                ++_player.NumShufflesExpended;
                //@TODO this may choose a set of spells that violates spell dependencies or memory constraints
                SetEquippedSpells(_player.CKnownSpells.ChooseRandom(_player.NumMemSlots));
            }
        }

        #endregion
    }
}
