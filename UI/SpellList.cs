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

        private DataStructures.Spell[] _spells;
        public ImageClickEvent? OnImageClick;
        private int? _lastIndex;

        public DataStructures.Spell[] SpellCollection {
            get => Spells;
            set => Spells = value;
        }

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

        public DataStructures.Spell[] Spells {
            get => _spells;
            set {
                _spells = value;
                RefreshImages();
            } 
        }

        private void HandleSelect(int index) {
            if (_lastIndex.HasValue && _lastIndex.Value < _spells.Length && _lastIndex.Value < layout.Items.Count) {
                layout.Items[_lastIndex.Value].Text = _spells[_lastIndex.Value].Name;
            }

            OnImageClick?.Invoke(_spells[index]);
            _lastIndex = index;
        }

        private void RefreshImages() {
            layout.Clear();
            if (_spells.Length == 0) {
                return;
            }

            var images = _spells.Select(spell => Image.FromFile(spell.ImagePath)).ToArray();
            var imageList = new ImageList{ImageSize = images[0].Size};
            imageList.Images.AddRange(images);
            layout.View = View.LargeIcon;
            layout.LargeImageList = imageList;
            for (int index = 0; index < _spells.Length; ++index) {
                layout.Items.Add(_spells[index].Name, index);
            }
        }

        public SpellList() {
            _spells = Array.Empty<DataStructures.Spell>();
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
