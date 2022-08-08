using System;
using System.Windows.Forms;
using DOS2Randomizer.DataStructures;
using DOS2Randomizer.Util;

namespace DOS2Randomizer.UI {
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
                    var window = new MatchWindow {Visible = true, Text = config.Name};
                    window.Activate();
                }
            }
        }
    }
}
