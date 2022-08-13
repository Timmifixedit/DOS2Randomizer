using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace DOS2Randomizer.UI {
    public delegate void ValueChangedEvent<in T>(T value);

    /// <summary>
    /// Base class for user control elements that manage a value
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BindingControl<T> : UserControl {
        public ValueChangedEvent<T>? OnValueChanged;

        /// <summary>
        /// Managed value
        /// </summary>
        public abstract T Value { get; set; }

        protected void HandleValueChanged() {
            OnValueChanged?.Invoke(Value);
        }
    }
}
