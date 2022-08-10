using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DOS2Randomizer.UI {

    public delegate void ImageClickEvent(DataStructures.Spell spell);
    public partial class SpellList : UserControl, ISpellCollection {

        private IEnumerable<DataStructures.Spell>? _spells;
        public ImageClickEvent? OnImageClick;
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

        public IEnumerable<DataStructures.Spell>? Spells {
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
                layout.Items.Add(Spells.ElementAt(index).Name, index);
            }
        }

        public SpellList() {
            InitializeComponent();
            layout.Click += (_, _) => HandleSelect(layout.SelectedIndices[0]);
            layout.KeyDown += (sender, args) => {
                if (args.KeyCode == Keys.Enter && layout.SelectedIndices.Count != 0) {
                    HandleSelect(layout.SelectedIndices[0]);
                }
            };
        }
    }
}
