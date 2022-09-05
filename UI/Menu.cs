using System;
using System.Windows.Forms;
using DOS2Randomizer.DataStructures;
using DOS2Randomizer.Util;

namespace DOS2Randomizer.UI {

    /// <summary>
    /// Main menu
    /// </summary>
    public partial class Menu : Form {
        public Menu() {
            InitializeComponent();
        }

        private void CreateConfig_Click(object sender, EventArgs e) {
            var configurator = new ConfigCreator {Visible = true};
            configurator.Activate();
        }

        private void spellConfigurator_Click(object sender, EventArgs e) {
            var configurator = new SpellConfigurator {Visible = true};
            configurator.Activate();
        }

        private void LoadConfig_Click(object sender, EventArgs e) {
            if (ConfigUtils.LoadConfigOrMigrate<MatchConfig>(out var configPath) is { } config) {
                var window = new MatchWindow(new MatchConfigGuard(config), configPath)
                    { Visible = true, Text = config.Name };
                window.Activate();
            }
        }

        private void migrateSpells_Click(object sender, EventArgs e) {
            var spells = ConfigUtils.LoadConfigOrMigrate<SpellListWrapper>(out _);
            if (spells is not null) {
                using var fileChooser = new SaveFileDialog
                    { AddExtension = true, DefaultExt = Resources.Misc.JsonExtension };
                if (fileChooser.ShowDialog() == DialogResult.OK) {
                    FileIo.SaveConfig(spells, fileChooser.FileName);
                }
            }
        }
    }
}
