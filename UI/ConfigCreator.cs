using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DOS2Randomizer.DataStructures;
using DOS2Randomizer.Util;

namespace DOS2Randomizer.UI {
    public partial class ConfigCreator : Form {
        #region Fields

        private Spell[] _spells;

        private Spell[] Spells {
            get => _spells;
            set {
                _spells = value;
                spellDesignPanel1.AllSpells = _spells;
                spellSearch.AllSpells = _spells;
            }
        }

        #endregion
        public ConfigCreator() {
            InitializeComponent();
            spellList.OnImageClick = spell => spellDesignPanel1.Spell = spell;
            spellSearch.ManagedCollection = spellList;
        }

        /// <summary>
        /// Checks if all data fields are set and all values are valid
        /// @TODO
        /// </summary>
        /// <returns>true if all fields are set correctly</returns>
        private bool CheckValues() {
            return true;
        }

        private void SaveButton_Click(object sender, System.EventArgs e) {
            if (!CheckValues()) {
                MessageBox.Show("Some data fields are missing");
                return;
            }

            using var fileChooser = new SaveFileDialog {DefaultExt = ".json", AddExtension = true};
            if (fileChooser.ShowDialog() == DialogResult.OK) {
                try {
                    using var file = fileChooser.OpenFile();
                    using var writer = new StreamWriter(file);
                    // @TODO serialize config and save
                } catch (IOException exception) {
                    MessageBox.Show(Resources.ErrorMessages.SaveError + exception.Message);
                } catch (UnauthorizedAccessException) {
                    MessageBox.Show("Access denied for file " + fileChooser.FileName);
                }
            }
        }

        private void import_Click(object sender, EventArgs e) {
            using var fileChooser = new OpenFileDialog{Filter = Resources.Misc.JsonFilter};
            if (fileChooser.ShowDialog() == DialogResult.OK) {
                Spells = FileIo.ImportSpells(fileChooser.FileName);
            }
        }
    }
}
