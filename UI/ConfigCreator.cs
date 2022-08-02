using System;
using System.IO;
using System.Windows.Forms;

namespace DOS2Randomizer.UI {
    public partial class ConfigCreator : Form {
        #region Fields

        #endregion
        public ConfigCreator() {
            InitializeComponent();
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
                    MessageBox.Show("Error saving config: " + exception.Message);
                } catch (UnauthorizedAccessException) {
                    MessageBox.Show("Access denied for file " + fileChooser.FileName);
                }
            }
        }
    }
}
