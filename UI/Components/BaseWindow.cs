using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DOS2Randomizer.UI.Components {
    public partial class BaseWindow : Form, IChoosableDesign {
        private DesignType _design = DesignType.Dark;
        public BaseWindow() {
            InitializeComponent();
            Load += (_, _) => SetDesign(Design);
        }
        public DesignType Design {
            get => _design;
            set {
                _design = value;
                SetDesign(value);
            }
        }

        private void SetDesign(DesignType type) {
            var colors = UI.Design.Get(type);
            BackColor = colors.BackColor;
            DarkModeHax.UseImmersiveDarkMode(Handle, type == DesignType.Dark);
            DesignHelper.ApplyDesign(type, Controls);
            designButton.Text = type == DesignType.Dark ? "Light" : "Dark";
        }

        private void SwitchDesign() {
            Design = Design == DesignType.Dark ? DesignType.Light : DesignType.Dark;
        }

        private void BaseWindow_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.D && e.Modifiers == Keys.Control) {
                SwitchDesign();
            }
        }

        private void designButton_Click(object sender, EventArgs e) {
            SwitchDesign();
        }
    }
}
