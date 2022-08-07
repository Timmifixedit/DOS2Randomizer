using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DOS2Randomizer.DataStructures;

namespace DOS2Randomizer.UI {
    public partial class SkillPointsPanel : BindingControl<Dictionary<Spell.School, int>> {

        private Dictionary<Spell.School, int> _schoolLevels;
        private TableLayoutPanel _layout;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Dictionary<Spell.School, int> Value {
            get => _schoolLevels;
            set {
                if (value == null) {
                    return;
                }
                _schoolLevels = value;
                foreach (Spell.School type in Enum.GetValues(typeof(Spell.School))) {
                    if (!_schoolLevels.ContainsKey(type)) {
                        throw new ArgumentException($"Dictionary does not contain school type {type.ToString()}");
                    }

                    ((LabeledValue) _layout.Controls[type.ToString()]).Value = _schoolLevels[type];
                }
            }

        }

        public SkillPointsPanel() {
            InitializeComponent();
            _schoolLevels = new Dictionary<Spell.School, int>();
            var schoolTypes = (Spell.School[]) Enum.GetValues(typeof(Spell.School));
            _layout = new TableLayoutPanel {ColumnCount = 1, RowCount = schoolTypes.Length, Dock = DockStyle.Fill};
            int row = 0;
            foreach (var type in schoolTypes) {
                var valBox = new LabeledValue {
                    Label = type.ToString(), Anchor = (AnchorStyles.Left | AnchorStyles.Right), SplitPercentage = 70,
                    Name = type.ToString()
                };
                _schoolLevels.Add(type, 0);
                valBox.OnValueChanged = value => {
                    var t = type;
                    _schoolLevels[t] = value;
                    HandleValueChanged();
                };

                _layout.Width = Math.Max(_layout.Width, valBox.Width);
                _layout.Height += valBox.Height;
                _layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
                _layout.Controls.Add(valBox, 0, row);
                ++row;
            }

            Height = _layout.Height;
            Controls.Add(_layout);
        }
    }
}
