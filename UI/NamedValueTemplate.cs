using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DOS2Randomizer.UI {

    public abstract partial class NamedValueTemplate<T> : BindingControl<T> {

        public TableLayoutPanel LayoutPanel => layout;
        public string Label {
            get => name.Text;
            set => name.Text = value;
        }

        public int SplitPercentage {
            get {
                var styles = layout.ColumnStyles;
                if (styles.Count != 2) {
                    throw new InvalidOperationException($"Invalid number of columns ({styles.Count}), expected 2");
                }

                if (styles[0].SizeType != SizeType.Percent) {
                    throw new InvalidOperationException($"Invalid size type, expected percentage, got {styles[0].SizeType}");
                }

                return Convert.ToInt32(styles[0].Width);
            }

            set {
                if (value < 0 || value > 100) {
                    throw new ArgumentException($"split percentage value must be in [0, 100], got {value}");
                }
                var styles = layout.ColumnStyles;
                if (styles.Count != 2) {
                    throw new InvalidOperationException($"Invalid number of columns ({styles.Count}), expected 2");
                }

                (styles[0].SizeType, styles[1].SizeType) = (SizeType.Percent, SizeType.Percent);
                (styles[0].Width, styles[1].Width) = (value, 100 - value);
            }
        }
        public NamedValueTemplate() {
            InitializeComponent();
            Height = name.Height;
        }
    }
}
