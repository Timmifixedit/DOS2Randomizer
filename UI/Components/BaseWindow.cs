using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ABI.Windows.UI;

namespace DOS2Randomizer.UI.Components
{
    public class BaseWindow : Form, IChoosableDesign
    {
        private DesignType _design = DesignType.Dark;

        public BaseWindow() {
            Load += (_, _) => SetDesign(Design);
        }

        public DesignType Design
        {
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
        }
    }
}
