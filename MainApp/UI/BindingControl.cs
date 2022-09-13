using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using DOS2Randomizer.UI.Components;

namespace DOS2Randomizer.UI {
    public delegate void ValueChangedEvent<in T>(T value);

    /// <summary>
    /// Base class for user control elements that manage a value
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BindingControl<T> : BaseControl {
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
