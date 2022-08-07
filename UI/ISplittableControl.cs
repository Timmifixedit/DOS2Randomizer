using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace DOS2Randomizer.UI {

    public interface ISplittableControl {
        public TableLayoutPanel LayoutPanel { get; }
        public int SplitPercentageProperty {
            get {
                var styles = LayoutPanel.ColumnStyles;
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
                var styles = LayoutPanel.ColumnStyles;
                if (styles.Count != 2) {
                    throw new InvalidOperationException($"Invalid number of columns ({styles.Count}), expected 2");
                }

                (styles[0].SizeType, styles[1].SizeType) = (SizeType.Percent, SizeType.Percent);
                (styles[0].Width, styles[1].Width) = (value, 100 - value);
            }
        }
    }

   /* public static class SplittableExtension {
        public static void SplitPercentage(this ISplittableControl control, int value) {
            control.SplitPercentageProperty = value;
        }

        public static int SplitPercentage(this ISplittableControl control) {
            return control.SplitPercentageProperty;
        }
    }*/
}
