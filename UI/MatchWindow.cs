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
    public partial class MatchWindow : Form {
        private readonly IConstMatchConfig _config;

        private ImmutableArray<Player> Players {
            get => _config.Players;
            set {
                _config.Players = value;
                GeneratePlayerPanels();
            }
        }

        private void GeneratePlayerPanels() {
            playersLayout.Controls.Clear();
            foreach (var player in Players) {
                var playerPanel = new PlayerPanel(player, _config) {
                    OnRemoveClick = RemovePlayer,
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

            Players = Players.Append(new Player()).ToImmutableArray();
            if (Players.Length >= MatchConfig.MaxNumPlayers) {
                addPlayer.Enabled = false;
            }
        }
        private void RemovePlayer(Player player) {
            var confirmed = MessageBox.Show(String.Format(Resources.Messages.ConfirmDeletePlayer, player.Name),
                "", MessageBoxButtons.OKCancel);
            if (confirmed == DialogResult.OK) {
                Players = Players.Except(new[] {player}).ToImmutableArray();
                addPlayer.Enabled = true;
            }
        }
    }
}
