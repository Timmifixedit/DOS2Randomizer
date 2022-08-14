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
            using var fileChooser = new OpenFileDialog{Filter = Resources.Misc.JsonFilter};
            if (fileChooser.ShowDialog() == DialogResult.OK) {
                var config = FileIo.ImportConfig<MatchConfig>(fileChooser.FileName);
                if (config != null) {
                    var window = new MatchWindow(new MatchConfigGuard(config)) { Visible = true, Text = config.Name };
                    window.Activate();
                }
            }
        }

        private void migrateSpells_Click(object sender, EventArgs e) {
            SpellListWrapper? spells = null;
            using (var fileChooser = new OpenFileDialog { Filter = Resources.Misc.JsonFilter }) {
                if (fileChooser.ShowDialog() == DialogResult.OK &&
                    FileIo.ImportConfig<SpellListWrapper>(fileChooser.FileName) is { } spellList) {
                    using var dirChooser = new FolderBrowserDialog { ShowNewFolderButton = false };
                    MessageBox.Show(Resources.Messages.SelectImages);
                    if (dirChooser.ShowDialog() == DialogResult.OK) {
                        spells = FileIo.MigrateSpellConfig(spellList, dirChooser.SelectedPath);
                    }
                }
            }

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
