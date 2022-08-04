using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DOS2Randomizer.DataStructures;

namespace DOS2Randomizer.UI {

    public partial class LabeledEnum<TEnum> : NamedValueTemplate<TEnum> {

        private ComboBox _comboBox;

        public override TEnum Value {
            get => (TEnum) _comboBox.SelectedItem;
            set => _comboBox.SelectedItem = value;
        }


        public LabeledEnum() {
            _comboBox = new ComboBox {
                Anchor = (AnchorStyles.Left | AnchorStyles.Right), DataSource = Enum.GetValues(typeof(TEnum)),
            };

            LayoutPanel.Controls.Add(_comboBox, 1, 0);
            _comboBox.SelectedValueChanged += (sender, args) => HandleValueChanged();
        }
    }

    public class LabeledSchoolType : LabeledEnum<Spell.School> {}

    public class LabeledAttribute : LabeledEnum<DataStructures.Attribute> {}
}
