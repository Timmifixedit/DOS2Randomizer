using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DOS2Randomizer.UI.Components {
    public class Plotter : ScottPlot.FormsPlot, IChoosableDesign {
        private DesignType _designType = DesignType.Dark;

        public DesignType Design {
            get => _designType;
            set {
                _designType = value;
                var design = UI.Design.Get(value);
                ForeColor = design.TextColor;
                BackColor = design.BackColor;
                Plot.Style(axisLabel: design.TextColor, dataBackground: design.EditBackColor, tick: design.TextColor,
                    grid: design.BackColor);
                BorderStyle = design.BorderStyle;
                Refresh();
            }
        }
    }
}
