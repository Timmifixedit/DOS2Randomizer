using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DOS2Randomizer.UI.Components {
    public class CheckBox : System.Windows.Forms.CheckBox, IChoosableDesign {
        private DesignType _design = DesignType.Dark;

        public DesignType Design {
            get => _design;
            set {
                _design = value;
                var design = UI.Design.Get(_design);
                BackColor = design.BackColor;
                ForeColor = design.TextColor;
                FlatStyle = design.FlatStyle;
                FlatAppearance.MouseOverBackColor = design.SelectedColor;
                FlatAppearance.CheckedBackColor = design.SelectedColor;
            }
        }
    }
}
