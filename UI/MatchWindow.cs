﻿using System;
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
        private MatchConfig _config;

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
                var playerPanel = new PlayerPanel
                    {Player = player, OnRemoveClick = () => RemovePlayer(player), OnAddSpellsClick = AddSpellsManually};
                playersLayout.Controls.Add(playerPanel);
            }
        }

        public MatchWindow([DisallowNull]MatchConfig config) {
            _config = config;
            InitializeComponent();
            Players ??= new Player[0];
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
            Players = Players.Except(new[] {player}).ToArray();
        }

        private void AddSpellsManually(PlayerPanel playerPanel) {
            var spellChooseDialog = new SpellChooseDialog(_config.Spells) {
                OnConfirm = value => { AddSpellsToPlayerPanel(value, playerPanel);},
                Visible = true
            };
            spellChooseDialog.Activate();
        }

        private void AddSpellsToPlayerPanel(Spell[] spells, PlayerPanel playerPanel) {
            var player = playerPanel.Player;
            player.KnownSpells = (player.KnownSpells ?? new Spell[0]).Concat(spells).Distinct().ToArray();
            playerPanel.Player = player;

        }
    }
}