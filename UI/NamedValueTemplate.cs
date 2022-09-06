using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DOS2Randomizer.UI {

    /// <summary>
    /// Base class for labeled user controls that manage some kind of value
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract partial class NamedValueTemplate<T> : BindingControl<T>, ISplittableControl, IChoosableDesign {
        public virtual DesignType Design {
            get => name.Design;
            set => name.Design = value;
        }

        public TableLayoutPanel LayoutPanel => layout;

        /// <summary>
        /// Displayed label of the control
        /// </summary>
        public string Label {
            get => name.Text;
            set => name.Text = value;
        }

        public int SplitPercentage {
            get => (this as ISplittableControl).SplitPercentageImpl;
            set => (this as ISplittableControl).SplitPercentageImpl = value;
        }

        public NamedValueTemplate() {
            InitializeComponent();
            Height = name.Height;
        }
    }
}
