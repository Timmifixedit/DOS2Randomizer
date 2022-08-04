using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using DOS2Randomizer.DataStructures;
using Newtonsoft.Json;

namespace DOS2Randomizer.Util {
    static class FileIo {
        public static Spell[] ImportSpells(string fileName) {
            Spell[] spells = null;
            try {
                using var file = File.OpenRead(fileName);
                using var reader = new StreamReader(file);
                spells = JsonConvert.DeserializeObject<Spell[]>(reader.ReadToEnd());
            } catch (JsonException) {
                MessageBox.Show(String.Format(Resources.ErrorMessages.JsonParseFailed, fileName));
            } catch (IOException exception) {
                MessageBox.Show(String.Format(Resources.ErrorMessages.FileOpenFailed, fileName) +
                                Environment.NewLine + exception.Message);
            }

            return spells;
        }
    }
}
