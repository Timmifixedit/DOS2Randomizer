using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DOS2Randomizer.UI {
    public partial class LabeledString : NamedValueTemplate {

        private TextBox _text;

        public string Value {
            get => _text.Text;
            set => _text.Text = value;
        }

        public LabeledString() {
            InitializeComponent();
            _text = new TextBox {Anchor = (AnchorStyles.Left | AnchorStyles.Right)};
            Layout.Controls.Add(_text, 1, 0);
        }
    }
}
