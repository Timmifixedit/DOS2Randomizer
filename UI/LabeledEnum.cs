using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DOS2Randomizer.DataStructures;

namespace DOS2Randomizer.UI {
    public partial class LabeledEnum<EnumType> : NamedValueTemplate {

        private ComboBox _comboBox;

        public EnumType Value {
            get => (EnumType) _comboBox.SelectedItem;
            set => _comboBox.SelectedItem = value;
        }

        public LabeledEnum() {
            _comboBox = new ComboBox {
                Anchor = (AnchorStyles.Left | AnchorStyles.Right), DataSource = Enum.GetValues(typeof(EnumType)),
            };
            Layout.Controls.Add(_comboBox, 1, 0);
        }
    }

    public class LabeledSchoolType : LabeledEnum<Spell.School> {}

    public class LabeledAttribute : LabeledEnum<DataStructures.Attribute> {}
}
