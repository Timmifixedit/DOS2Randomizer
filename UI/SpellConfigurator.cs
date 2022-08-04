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
using Newtonsoft.Json;
using MessageBox = System.Windows.Forms.MessageBox;

namespace DOS2Randomizer.UI {
    public partial class SpellConfigurator : Form {
        public SpellConfigurator() {
            InitializeComponent();
            spellList.OnImageClick += spell => { spellDesignPanel.Spell = spell; };
        }

        private void import_Click(object sender, EventArgs e) {
            using var fileChooser = new OpenFileDialog{Filter = "json files (*.json) | *.json"};
            if (fileChooser.ShowDialog() == DialogResult.OK) {
                Spell[] spells = null;
                try {
                    var file = fileChooser.OpenFile();
                    var reader = new StreamReader(file);
                    spells = JsonConvert.DeserializeObject<Spell[]>(reader.ReadToEnd());
                } catch (JsonException) {
                    MessageBox.Show(String.Format(Resources.ErrorMessages.JsonParseFailed, fileChooser.FileName));
                } catch (IOException exception) {
                    MessageBox.Show(String.Format(Resources.ErrorMessages.FileOpenFailed, fileChooser.FileName) +
                                    Environment.NewLine + exception.Message);
                }

                spellList.Spells = spells;
                spellDesignPanel.AllSpells = spells;
            }
        }

        private void save_Click(object sender, EventArgs e) {
            if (spellList.Spells is null) {
                MessageBox.Show(Resources.ErrorMessages.NoSpells);
                return;
            }

            using var fileChooser = new SaveFileDialog { AddExtension = true, DefaultExt = ".json"};
            if (fileChooser.ShowDialog() == DialogResult.OK) {
                try {
                    using var file = fileChooser.OpenFile();
                    using var writer = new StreamWriter(file);
                    var json = JsonConvert.SerializeObject(spellList.Spells);
                    writer.Write(json);
                } catch (IOException exception) {
                    MessageBox.Show(Resources.ErrorMessages.SaveError + exception.Message);
                }
            }
        }

        private void create_Click(object sender, EventArgs e) {
            using var dirChooser = new FolderBrowserDialog {ShowNewFolderButton = false};
            if (dirChooser.ShowDialog() == DialogResult.OK) {
                var files = Directory.GetFiles(dirChooser.SelectedPath, "*.png", SearchOption.AllDirectories);
                System.Diagnostics.Debug.WriteLine("Found the following png files");
                foreach (var file in files) {
                    System.Diagnostics.Debug.WriteLine(file);
                }

                var spells = files.Select(imageFile => new Spell("<unknown>", imageFile)).ToArray();
                spellList.Spells = spells;
                spellDesignPanel.AllSpells = spells;
            }
        }
    }
}
