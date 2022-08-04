using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DOS2Randomizer.DataStructures;

namespace DOS2Randomizer.UI {
    class LabeledSelection<T> : NamedValueTemplate<T[]> {
        private CheckedListBox _listBox;
        private T[] _items;
        private string _displayMember;

        public override T[] Value {
            get => _listBox.CheckedItems.Cast<T>().ToArray();
            set {
                for (int i = 0; i < _listBox.Items.Count; i++) {
                    _listBox.SetItemChecked(i, false);
                }

                if (value != null) {
                    foreach (var val in value) {
                        int index = _listBox.Items.IndexOf(val);
                        if (index != -1) {
                            _listBox.SetItemChecked(index, true);
                        }
                    }
                }
            }
        }

        public T[] Data {
            get => _items;
            set {
                _items = value;
                _listBox.DataSource = _items;
                _listBox.DisplayMember = DisplayMember;
            }
        }

        public string DisplayMember {
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

    class LabeledSpellSelection : LabeledSelection<Spell> {
        public LabeledSpellSelection() {
            DisplayMember = typeof(Spell).GetProperties()[0].Name;
        }
    }
}
