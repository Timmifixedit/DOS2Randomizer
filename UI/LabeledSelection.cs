using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using DOS2Randomizer.DataStructures;

namespace DOS2Randomizer.UI {
    class LabeledSelection<T> : NamedValueTemplate<T[]> {
        private CheckedListBox _listBox;
        private T[] _items;

        public override T[] Value {
            get {
                T[] ret = new T[_listBox.CheckedItems.Count];
                int index = 0;
                foreach (var checkedItem in _listBox.CheckedItems) {
                    ret[index++] = (T) checkedItem;
                }

                return ret;
            }
            set {
                if (value is null) {
                    return;
                }

                foreach (var val in value) {
                    _listBox.SetItemChecked(_listBox.Items.IndexOf(val), true);
                }
            }
        }

        public T[] Data {
            get => _items;
            set {
                _items = value;
                _listBox.DataSource = _items;
            }
        }

        private void HandleCheck(ItemCheckEventArgs e) {
            var checkedItems = new List<T>();
            foreach (T item in _listBox.CheckedItems) {
                checkedItems.Add(item);
            }

            if (e.NewValue == CheckState.Checked) {
                checkedItems.Add((T) _listBox.Items[e.Index]);
            } else {
                checkedItems.Remove((T) _listBox.Items[e.Index]);
            }

            OnValueChanged?.Invoke(checkedItems.ToArray());
        }

        public LabeledSelection() {
            _listBox = new CheckedListBox {CheckOnClick = true, Dock = DockStyle.Fill};
            _listBox.ItemCheck += (sender, args) => HandleCheck(args);

                LayoutPanel.Controls.Add(_listBox, 1, 0);
        }
    }

    class LabeledSpellTypeSelection : LabeledSelection<Spell.Type> {}
    class LabeledSpellSelection : LabeledSelection<Spell> {}
}
