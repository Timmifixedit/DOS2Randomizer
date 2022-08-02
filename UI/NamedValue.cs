using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DOS2Randomizer.UI {
    public partial class NamedValue : UserControl {

        public string Label {
            get => name.Text;
            set => name.Text = value;
        }

        public int Value {
            get => Convert.ToInt32(value.Value);
            set => this.value.Value = value;
        }

        public NamedValue() {
            InitializeComponent();
        }
    }
}
