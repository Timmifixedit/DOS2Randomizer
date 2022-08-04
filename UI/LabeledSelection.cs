using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DOS2Randomizer.DataStructures;

namespace DOS2Randomizer.UI {
    class LabeledSelection<T> : NamedValueTemplate<IEnumerable<T>> {
        private CheckedListBox _listBox;
        private IEnumerable<T> _items;
        private string _displayMember;

        public override IEnumerable<T> Value {
            get {
                var ret = new List<T>();
                foreach (T checkedItem in _listBox.CheckedItems) {
                    ret.Add(checkedItem);
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

        public IEnumerable<T> Data {
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
