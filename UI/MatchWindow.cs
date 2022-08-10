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
        private void RemovePlayer(PlayerPanel panel) {
            var confirmed = MessageBox.Show(String.Format(Resources.Messages.ConfirmDeletePlayer, panel.Player.Name),
                "", MessageBoxButtons.OKCancel);
            if (confirmed == DialogResult.OK) {
                Players = Players.Except(new[] {panel.Player}).ToArray();
                addPlayer.Enabled = true;
            }
        }

        private void ConfigurePlayerSpells(PlayerPanel playerPanel) {
            var player = playerPanel.Player;
            var spellChooseDialog = new SpellChooseDialog(_config.Spells.Except(player.KnownSpells), player.KnownSpells) {
                OnConfirm = playerPanel.SetPlayerSpells,
                Visible = true
            };
            spellChooseDialog.Activate();
        }

        private void DrawNewSpells(PlayerPanel panel) {
            var player = panel.Player;
            var level = player.Level;
            if (_config.LevelSpecificEvents.Length < level) {
                throw new InvalidOperationException("not enough level specific entries");
            }

            var maxSpellsToThisLevel = _config.LevelSpecificEvents.Take(level).Select(data => data.NewSpells).Sum();
            if (player.KnownSpells.Length < maxSpellsToThisLevel) {
                var numSpellsToChoose = Math.Min(_config.K, maxSpellsToThisLevel - player.KnownSpells.Length);
                // @TODO generateSpells(player, _match, N)
                // For testing purposes:
                var spellSelection = _config.Spells.Except(player.KnownSpells).Take(3);
            } else {
                MessageBox.Show(String.Format(Resources.Messages.MaxNumberSpellsReached, player.Name,
                    maxSpellsToThisLevel));
            }
        }
    }
}
