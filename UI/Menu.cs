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

        private const int DWMWA_USE_IMMERSIVE_DARK_MODE_BEFORE_20H1 = 19;
        private const int DWMWA_USE_IMMERSIVE_DARK_MODE = 20;

        // stolen from https://stackoverflow.com/questions/57124243/winforms-dark-title-bar-on-windows-10
        [DllImport("DwmApi")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, int[] attrValue, int attrSize);

        protected override void OnHandleCreated(EventArgs e) {
            if (DwmSetWindowAttribute(Handle, DWMWA_USE_IMMERSIVE_DARK_MODE_BEFORE_20H1, new[] { 1 }, 4) != 0) {
                DwmSetWindowAttribute(Handle, DWMWA_USE_IMMERSIVE_DARK_MODE, new[] { 1 }, 4);
            }
        }

        #endregion
    }
}
