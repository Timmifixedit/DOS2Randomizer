using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DOS2Randomizer.DataStructures;

namespace DOS2Randomizer.UI {
    public partial class SpellConfigurator : Form {
        public SpellConfigurator() {
            InitializeComponent();
            spellList.OnImageClick += spell => { spellDesignPanel1.Spell = spell; };
        }

        private void import_Click(object sender, EventArgs e) {
            using var dirChooser = new FolderBrowserDialog {ShowNewFolderButton = false};
            if (dirChooser.ShowDialog() == DialogResult.OK) {
                var files = Directory.GetFiles(dirChooser.SelectedPath, "*.png", SearchOption.AllDirectories);
                System.Diagnostics.Debug.WriteLine("Found the following png files");
                var spells = files.Select(imageFile => new Spell("<unknown>", imageFile)).ToArray();
                spellList.Spells = spells;
            }
        }
    }
}
