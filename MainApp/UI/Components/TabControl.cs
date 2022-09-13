using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DOS2Randomizer.UI.Components {
    public class TabControl : System.Windows.Forms.TabControl, IChoosableDesign {
        private DesignType _designType = DesignType.Dark;
        public DesignType Design {
            get => _designType;
            set {
                _designType = value;
                DesignHelper.ApplyDesign(value, Controls);
                var design = UI.Design.Get(value);
                foreach (TabPage page in TabPages) {
                    page.BackColor = design.BackColor;
                }
            }
        }
    }
}
