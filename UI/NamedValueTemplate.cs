using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DOS2Randomizer.UI {

    public abstract partial class NamedValueTemplate<T> : BindingControl<T>, ISplittableControl {

        public TableLayoutPanel LayoutPanel => layout;
        public string Label {
            get => name.Text;
            set => name.Text = value;
        }

        public int SplitPercentage {
            get => (this as ISplittableControl).SplitPercentageProperty;
            set => (this as ISplittableControl).SplitPercentageProperty = value;
        }

        public NamedValueTemplate() {
            InitializeComponent();
            Height = name.Height;
        }
    }
}
