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
    public partial class SpellList : UserControl {

        private DataStructures.Spell[] _spells;
        public ImageClickEvent OnImageClick;

        public DataStructures.Spell[] Spells {
            get => _spells;
            set {
                _spells = value;
                if (_spells != null) {
                    RefreshImages();
                }
            } 
        }

        private void HandleSelect(int index) {   
            OnImageClick?.Invoke(_spells[index]);
        }

        private void RefreshImages() {
            layout.Clear();
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
            InitializeComponent();
            layout.Click += (sender, args) => HandleSelect(layout.SelectedIndices[0]);
            layout.KeyDown += (sender, args) => {
                if (args.KeyCode == Keys.Enter && layout.SelectedIndices.Count != 0) {
                    HandleSelect(layout.SelectedIndices[0]);
                }
            };
        }
    }
}
