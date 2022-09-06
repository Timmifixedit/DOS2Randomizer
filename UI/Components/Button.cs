using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOS2Randomizer.UI.Components {
    public class Button : System.Windows.Forms.Button, IChoosableDesign {
        private DesignType _design = DesignType.Dark;

        public DesignType Design {
            get => _design;
            set {
                _design = value;
                var design = UI.Design.Get(_design);
                BackColor = design.ControlColor;
                FlatStyle = design.FlatStyle;
                ForeColor = design.TextColor;
                FlatAppearance.BorderSize = design.FlatButtonAppearance.BorderSize;
                FlatAppearance.MouseOverBackColor = design.FlatButtonAppearance.MouseOverBackColor;
            }
        }
    }
}
