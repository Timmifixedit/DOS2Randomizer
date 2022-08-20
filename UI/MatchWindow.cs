using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DOS2Randomizer.DataStructures;
using DOS2Randomizer.Logic;
using DOS2Randomizer.Util;

namespace DOS2Randomizer.UI {

    /// <summary>
    /// Form that is used during a match
    /// </summary>
    public partial class MatchWindow : Form {
        private readonly MatchConfigGuard _config;
        private readonly SaveManager _saveManager;

        private ImmutableArray<IMutablePlayer> Players {
            get => _config.Get.Players;
            set {
                _config.Get.Players = value;
                GeneratePlayerPanels();
            }
        }

        private void GeneratePlayerPanels() {
            playersLayout.Controls.Clear();
            foreach (var player in Players) {
                var playerPanel = new PlayerPanel(player, _config.Get) {
                    OnRemoveClick = RemovePlayer,
                };
                playersLayout.Controls.Add(playerPanel);
            }
        }

        public MatchWindow(MatchConfigGuard config, string? savePath = null) {
            _config = config;
            InitializeComponent();
            _saveManager = new SaveManager(savePath);
            if (Players.Length >= MatchConfig.MaxNumPlayers) {
                addPlayer.Enabled = false;
            }

            GeneratePlayerPanels();
        }

        private void save_Click(object sender, EventArgs e) {
            if (_saveManager.GetNewPath() is {} path) {
                _config.Save(path);
            }
        }

        private void addPlayer_Click(object sender, EventArgs e) {
            if (Players.Length >= MatchConfig.MaxNumPlayers) {
                MessageBox.Show(Resources.ErrorMessages.MaxNumPlayers);
                return;
            }

            Players = Players.Append(new Player()).ToImmutableArray();
            if (Players.Length >= MatchConfig.MaxNumPlayers) {
                addPlayer.Enabled = false;
            }
        }
        private void RemovePlayer(IMutablePlayer player) {
            var confirmed = MessageBox.Show(String.Format(Resources.Messages.ConfirmDeletePlayer, player.Name),
                "", MessageBoxButtons.OKCancel);
            if (confirmed == DialogResult.OK) {
                Players = Players.Except(new[] {player}).ToImmutableArray();
                addPlayer.Enabled = true;
            }
        }

        private void MatchWindow_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.S && e.Modifiers == Keys.Control && _saveManager.GetPath() is { } path) {
                _config.Save(path);
            }
        }
    }
}
