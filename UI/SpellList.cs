using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        private void HandleClick(int index) {
            OnImageClick?.Invoke(_spells[index]);
        }

        private void RefreshImages() {
            layout.Controls.Clear();
            for (int index = 0; index < _spells.Length; ++index) {
                var picture = new PictureBox {Image = Image.FromFile(_spells[index].ImagePath), SizeMode = PictureBoxSizeMode.AutoSize};
                var i = index;
                picture.Click += (sender, args) => {
                    HandleClick(i);
                };

                layout.Controls.Add(picture);
            }

            layout.Refresh();
        }

        public SpellList() {
            InitializeComponent();
        }
    }
}
