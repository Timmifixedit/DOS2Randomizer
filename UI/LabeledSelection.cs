using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DOS2Randomizer.DataStructures;

namespace DOS2Randomizer.UI {
    class LabeledSelection<T> : NamedValueTemplate<IEnumerable<T>> {
        private readonly CheckedListBox _listBox;
        private IEnumerable<T>? _items;
        private string? _displayMember;

                
        [AllowNull]
        public override IEnumerable<T> Value {
            get => _listBox.CheckedItems.Cast<T>().ToArray();
            set {
                for (int i = 0; i < _listBox.Items.Count; i++) {
                    _listBox.SetItemChecked(i, false);
                }

                if (value == null) {
                    return;
                }

                foreach (var val in value) {
                    if (val is not null && _listBox.Items.IndexOf(val) is var index && index != -1) {
                        _listBox.SetItemChecked(index, true);
                    }
                }
            }
        }

        [AllowNull]
        public IEnumerable<T> Data {
            get => _items ?? Array.Empty<T>();
            set {
                _items = value;
                _listBox.DataSource = _items;
                _listBox.DisplayMember = DisplayMember;
            }
        }

        public string? DisplayMember {
            get => _displayMember;
            set {
                _displayMember = value;
                _listBox.DisplayMember = _displayMember;
            }
        }

        private void HandleCheck(ItemCheckEventArgs e) {
            if (OnValueChanged == null || OnValueChanged.GetInvocationList().Length == 0) {
                return;
            }

            var checkedItems = _listBox.CheckedItems.Cast<T>().ToList();
            if (e.NewValue == CheckState.Checked) {
                checkedItems.Add((T) _listBox.Items[e.Index]);
            } else {
                checkedItems.Remove((T) _listBox.Items[e.Index]);
            }

            OnValueChanged(checkedItems.ToArray());
        }

        public LabeledSelection() {
            _listBox = new CheckedListBox {CheckOnClick = true, Dock = DockStyle.Fill};
            _listBox.ItemCheck += (sender, args) => HandleCheck(args);
            LayoutPanel.Controls.Add(_listBox, 1, 0);
        }
    }

    class LabeledSpellTypeSelection : LabeledSelection<Spell.Type> {}

    class LabeledSpellSelection : LabeledSelection<Spell>, ISpellCollection {
        public LabeledSpellSelection() {
            DisplayMember = typeof(Spell).GetProperties()[0].Name;
        }

        public IEnumerable<Spell>? Spells {
            get => Data;
            set => Data = value;
        }
    }

    class LabeledSkillTypeSelection : LabeledSelection<Player.SkillType> {
        public LabeledSkillTypeSelection() {
            Data = (Player.SkillType[]) Enum.GetValues(typeof(Player.SkillType));
        }
    }
}
