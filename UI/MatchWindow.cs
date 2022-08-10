using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DOS2Randomizer.DataStructures;
using DOS2Randomizer.Util;

namespace DOS2Randomizer.UI {
    public partial class MatchWindow : Form {
        private readonly MatchConfig _config;

        private Player[] Players {
            get => _config.Players;
            set {
                _config.Players = value;
                GeneratePlayerPanels();
            }
        }

        private void GeneratePlayerPanels() {
            playersLayout.Controls.Clear();
            foreach (var player in Players) {
                var playerPanel = new PlayerPanel(player) {
                    OnRemoveClick = RemovePlayer,
                    OnConfigureSpells = ConfigurePlayerSpells,
                    OnDrawSpells = DrawNewSpells
                };
                playersLayout.Controls.Add(playerPanel);
            }
        }

        public MatchWindow(MatchConfig config) {
            _config = config;
            InitializeComponent();
            if (Players.Length >= MatchConfig.MaxNumPlayers) {
                addPlayer.Enabled = false;
            }

            GeneratePlayerPanels();
        }

        private void save_Click(object sender, EventArgs e) {
            using var fileChooser = new SaveFileDialog {AddExtension = true, DefaultExt = Resources.Misc.JsonExtension};
            if (fileChooser.ShowDialog() == DialogResult.OK) {
                FileIo.SaveConfig(_config, fileChooser.FileName);
            }
        }

        private void addPlayer_Click(object sender, EventArgs e) {
            if (Players.Length >= MatchConfig.MaxNumPlayers) {
                MessageBox.Show(Resources.ErrorMessages.MaxNumPlayers);
                return;
            }

            Players = Players.Append(new Player()).ToArray();
            if (Players.Length >= MatchConfig.MaxNumPlayers) {
                addPlayer.Enabled = false;
            }
        }
        private void RemovePlayer(Player player) {
            var confirmed = MessageBox.Show(String.Format(Resources.Messages.ConfirmDeletePlayer, player.Name),
                "", MessageBoxButtons.OKCancel);
            if (confirmed == DialogResult.OK) {
                Players = Players.Except(new[] {player}).ToArray();
                addPlayer.Enabled = true;
            }
        }

        private void ConfigurePlayerSpells(PlayerPanel playerPanel, Spell[] knownSpells) {
            var spellChooseDialog = new SpellChooseDialog(_config.Spells.Except(knownSpells), knownSpells) {
                FromListName = "Available Spells",
                ToListName = "Known Spells",
                OnConfirm = playerPanel.SetPlayerSpells,
                Visible = true
            };
            spellChooseDialog.Activate();
        }

        private void DrawNewSpells(PlayerPanel panel, int level, Spell[] knownSpells) {
            if (_config.LevelSpecificEvents.Length < level) {
                throw new InvalidOperationException("not enough level specific entries");
            }

            var maxSpellsToThisLevel = _config.LevelSpecificEvents.Take(level).Select(data => data.NewSpells).Sum();
            if (knownSpells.Length < maxSpellsToThisLevel) {
                var numSpellsToChoose = Math.Min(_config.K, maxSpellsToThisLevel - knownSpells.Length);
                // @TODO generateSpells(player, _match, N)
                // For testing purposes:
                var spellSelection = _config.Spells.Except(knownSpells).Take(3);
                var spellChooseDialog = new ChooseKDialog(spellSelection, numSpellsToChoose)
                    { OnConfirm = spells => { panel.SetPlayerSpells(knownSpells.Concat(spells)); }, Visible = true };
                spellChooseDialog.Activate();
            } else {
                MessageBox.Show(String.Format(Resources.Messages.MaxNumberSpellsReached, level));
            }
        }
    }
}
