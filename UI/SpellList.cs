using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DOS2Randomizer.UI {

    /// <summary>
    /// User control that displays a list of spells
    /// </summary>
    /// <typeparam name="T">type of spell</typeparam>
    public partial class SpellListBase<T> : UserControl, ISpellCollection<T> where T: DataStructures.IConstSpell {

        private IEnumerable<T>? _spells;

        /// <summary>
        /// Event that is triggered when a spell is selected
        /// </summary>
        public Action<T>? OnImageClick;
        private int? _lastIndex;

        public void SelectNext() {
            if (_lastIndex.HasValue && _lastIndex.Value < layout.Items.Count - 1) {
                layout.Items[_lastIndex.Value + 1].Selected = true;
                HandleSelect(_lastIndex.Value + 1);
            }
        }

        public void SelectPrevious() {
            if (_lastIndex.HasValue && _lastIndex.Value > 0) {
                layout.Items[_lastIndex.Value - 1].Selected = true;
                HandleSelect(_lastIndex.Value - 1);
            }
        }

        public IEnumerable<T>? Spells {
            get => _spells;
            set {
                _spells = value;
                RefreshImages();
            } 
        }

        private void HandleSelect(int index) {
            if (Spells is null) {
                return;
            }

            if (_lastIndex.HasValue && _lastIndex.Value < Spells.Count() && _lastIndex.Value < layout.Items.Count) {
                layout.Items[_lastIndex.Value].Text = Spells.ElementAt(_lastIndex.Value).Name;
            }

            OnImageClick?.Invoke(Spells.ElementAt(index));
            _lastIndex = index;
        }

        private void RefreshImages() {
            layout.Clear();
            if (Spells is null || !Spells.Any()) {
                return;
            }

            var images = Spells.Select(spell => Image.FromFile(spell.ImagePath)).ToArray();
            var imageList = new ImageList{ImageSize = images[0].Size};
            imageList.Images.AddRange(images);
            layout.View = View.LargeIcon;
            layout.LargeImageList = imageList;
            for (int index = 0; index < Spells.Count(); ++index) {
                var spell = Spells.ElementAt(index);
                var sb = new StringBuilder();
                foreach (var (school, value) in spell.SchoolRequirements) {
                    if (value > 0) {
                        sb.AppendLine($"{school.ToString()}: {value}");
                    }
                }

                var item = new ListViewItem(spell.Name, index) { ToolTipText = sb.ToString() };
                layout.Items.Add(item);
            }

        }

        public SpellListBase() {
            InitializeComponent();
            layout.BackColor = SystemColors.ControlDarkDark;
            layout.ShowItemToolTips = true;
            layout.Click += (_, _) => HandleSelect(layout.SelectedIndices[0]);
            layout.KeyUp += (_, args) => {
                if (args.KeyCode is Keys.Left or Keys.Right && layout.SelectedIndices.Count != 0) {
                    HandleSelect(layout.SelectedIndices[0]);
                }
            };
        }
    }

    public class SpellList : SpellListBase<DataStructures.Spell> {}
    public class CSpellList : SpellListBase<DataStructures.IConstSpell> {}
}
