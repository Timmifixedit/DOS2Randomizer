using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text;
using System.Windows.Forms;
using DOS2Randomizer.DataStructures;
using Newtonsoft.Json;

namespace DOS2Randomizer.Util {
    static class FileIo {
        public static T? ImportConfig<T>(string fileName) where T : class {
            T? spells = null;
            try {
                using var file = File.OpenRead(fileName);
                using var reader = new StreamReader(file);
                spells = JsonConvert.DeserializeObject<T>(reader.ReadToEnd());
            } catch (JsonException e) {
                MessageBox.Show(String.Format(Resources.ErrorMessages.JsonParseFailed, fileName) + Environment.NewLine +
                                e.Message);
            } catch (IOException exception) {
                MessageBox.Show(String.Format(Resources.ErrorMessages.FileOpenFailed, fileName) +
                                Environment.NewLine + exception.Message);
            }

            return spells;
        }

        public static void SaveConfig<T>(T config, string fileName) {
            try {
                using var file = File.Open(fileName, FileMode.Create);
                using var writer = new StreamWriter(file);
                var json = JsonConvert.SerializeObject(config);
                writer.Write(json);
            } catch (IOException exception) {
                MessageBox.Show(Resources.ErrorMessages.SaveError + exception.Message);
            } catch (JsonSerializationException e) {
                MessageBox.Show(Resources.ErrorMessages.JsonSerializeFailed + e.Message);
            }
        }
    }
}
