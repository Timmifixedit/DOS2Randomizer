using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DOS2Randomizer.UI {
    public partial class LabeledValue : NamedValueTemplate<int> {

        private NumericUpDown _val;

        public override int Value {
            get => Convert.ToInt32(_val.Value);
            set => _val.Value = value;
        }

        public int Max {
            get => Convert.ToInt32(_val.Maximum);
            set => _val.Maximum = value;
        }

        public int Min{
            get => Convert.ToInt32(_val.Minimum);
            set => _val.Minimum = value;
        }

        public LabeledValue() {
            InitializeComponent();
            _val = new NumericUpDown{Anchor = AnchorStyles.Left}; 
            LayoutPanel.Controls.Add(_val, 1, 0);
            _val.ValueChanged += (sender, args) => HandleValueChanged();
            Height = Math.Max(Height, _val.Height);
        }
    }
}
