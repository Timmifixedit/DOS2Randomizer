using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DOS2Randomizer.UI {
    public class PointsPanel<T> : BindingControl<Dictionary<T, int>> where T : Enum {

        private Dictionary<T, int> _pointLevels;
        private TableLayoutPanel _layout;
        public T[] ExcludedValues { get; set; }

        public PointsPanel(IEnumerable<T> excludedValues) {
            ExcludedValues = excludedValues?.ToArray();
            _pointLevels = new Dictionary<T, int>();
            var schoolTypes = (T[]) Enum.GetValues(typeof(T));
            _layout = new TableLayoutPanel {ColumnCount = 1, RowCount = schoolTypes.Length, Dock = DockStyle.Fill};
            int row = 0;
            foreach (var type in schoolTypes.Except(ExcludedValues ?? Array.Empty<T>())) {
                var valBox = new LabeledValue {
                    Label = type.ToString(), Anchor = (AnchorStyles.Left | AnchorStyles.Right), SplitPercentage = 70,
                    Name = type.ToString()
                };
                _pointLevels.Add(type, 0);
                valBox.OnValueChanged = value => {
                    var t = type;
                    _pointLevels[t] = value;
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

        public PointsPanel() : this(null) { }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Dictionary<T, int> Value {
            get => _pointLevels;
            set {
                if (value == null) {
                    return;
                }
                _pointLevels = value;
                foreach (T type in Enum.GetValues(typeof(T))) {
                    if (ExcludedValues != null && ExcludedValues.Contains(type)) {
                        continue;
                    }

                    if (!_pointLevels.ContainsKey(type)) {
                        throw new ArgumentException($"Dictionary does not contain type {type.ToString()}");
                    }

                    ((LabeledValue) _layout.Controls[type.ToString()]).Value = _pointLevels[type];
                }
            }

        }
    }

    public class SkillPointsPanel : PointsPanel<DataStructures.Spell.School> {}

    public class AttributePointsPanel : PointsPanel<DataStructures.Attribute> {
        public AttributePointsPanel() : base(new []{DataStructures.Attribute.None}) {}
    }
}
