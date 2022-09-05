using System;
using System.Runtime.InteropServices;
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

        #region Title bar hax

        protected override void OnHandleCreated(EventArgs e) {
            DarkModeHax.UseImmersiveDarkMode(Handle, true);
        }

        #endregion
    }
}
