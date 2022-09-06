using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DOS2Randomizer.DataStructures;

namespace DOS2Randomizer.UI {

    /// <summary>
    /// User control that provides a labeled combobox for enum values
    /// </summary>
    /// <typeparam name="TEnum"></typeparam>
    public class LabeledEnum<TEnum> : NamedValueTemplate<TEnum> {

        private readonly Components.ComboBox _comboBox;

        public override TEnum Value {
            get => (TEnum) _comboBox.SelectedItem;
            set => _comboBox.SelectedItem = value;
        }


        public LabeledEnum() {
            _comboBox = new Components.ComboBox
                { Anchor = (AnchorStyles.Left | AnchorStyles.Right), DataSource = Enum.GetValues(typeof(TEnum)) };

            LayoutPanel.Controls.Add(_comboBox, 1, 0);
            _comboBox.SelectedValueChanged += (sender, args) => HandleValueChanged();
        }
    }

    public class LabeledAttribute : LabeledEnum<DataStructures.Attribute> {}

    public class LabeledEquipType : LabeledEnum<Player.SkillType> {}

    public class LabeledSchoolType : LabeledEnum<Spell.School> {}

    public class LabeledDmgType : LabeledEnum<Player.WeaponDmgType> {}
}
