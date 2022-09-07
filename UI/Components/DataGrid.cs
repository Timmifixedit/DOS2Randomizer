using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DOS2Randomizer.UI.Components {
    public class DataGrid : DataGridView, IChoosableDesign {
        private DesignType _design = DesignType.Dark;
        public DesignType Design {
            get => _design;
            set {
                _design = value;
                var design = UI.Design.Get(value);
                DefaultCellStyle.BackColor = design.BackColor;
                DefaultCellStyle.ForeColor = design.TextColor;
                ColumnHeadersDefaultCellStyle.BackColor = design.ControlColor;
                ColumnHeadersDefaultCellStyle.ForeColor = design.TextColor;
                EnableHeadersVisualStyles = false;
            }
        }
    }
}
