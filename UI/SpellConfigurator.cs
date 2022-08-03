using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DOS2Randomizer.DataStructures;

namespace DOS2Randomizer.UI {
    public partial class SpellConfigurator : Form {
        public SpellConfigurator() {
            InitializeComponent();
            imageList1.Spells = new[] {
                new Spell("test1", "../../../Resources/Icons/Aero/1.png"),
                new Spell("test2", "../../../Resources/Icons/Aero/2.png"),
            };
            imageList1.OnImageClick += spell => MessageBox.Show(spell.Name);
        }
    }
}
