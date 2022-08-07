using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace DOS2Randomizer.UI {
    public delegate void ValueChangedEvent<in T>(T value);

    public abstract class BindingControl<T> : UserControl {
        public ValueChangedEvent<T> OnValueChanged;

        public abstract T Value { get; set; }

        protected void HandleValueChanged() {
            OnValueChanged?.Invoke(Value);
        }
    }
}
