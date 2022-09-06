using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DOS2Randomizer.UI {
    /// <summary>
    /// User control that provides a labeled text field
    /// </summary>
    public partial class LabeledString : NamedValueTemplate<string> {

        private readonly Components.TextBox _text;

        public override DesignType Design {
            get => base.Design;
            set {
                base.Design = value;
                _text.Design = value;
            }
        }

        public override string Value {
            get => _text.Text;
            set => _text.Text = value;
        }

        public LabeledString() {
            InitializeComponent();
            _text = new Components.TextBox {Anchor = (AnchorStyles.Left | AnchorStyles.Right)};
            LayoutPanel.Controls.Add(_text, 1, 0);
            _text.TextChanged += (_, _) => HandleValueChanged();
            Height = Math.Max(Height, _text.Height);
        }
    }
}
