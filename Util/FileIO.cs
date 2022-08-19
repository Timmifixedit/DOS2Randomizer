using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DOS2Randomizer.DataStructures;
using Newtonsoft.Json;

namespace DOS2Randomizer.Util {
    /// <summary>
    /// static class used for (de-)serializing configs
    /// </summary>
    static class FileIo {

        /// <summary>
        /// Deserialize a config
        /// </summary>
        /// <typeparam name="T">type of config</typeparam>
        /// <param name="fileName">path to file</param>
        /// <returns>deserialized config or null if deserialization failed</returns>
        public static T? ImportConfig<T>(string fileName) where T : class, ISerilizable {
            T? spells = null;
            try {
                using var file = File.OpenRead(fileName);
                using var reader = new StreamReader(file);
                spells = JsonConvert.DeserializeObject<T>(reader.ReadToEnd());
            } catch (JsonException e) {
                MessageBox.Show(String.Format(Resources.ErrorMessages.JsonParseFailed, fileName) + Environment.NewLine +
                                e.Message);
            } catch (FileNotFoundException e) {
                MessageBox.Show(e.Message);
            } catch (IOException exception) {
                MessageBox.Show(String.Format(Resources.ErrorMessages.FileOpenFailed, fileName) +
                                Environment.NewLine + exception.Message);
            } catch (ArgumentException) {
                MessageBox.Show(Resources.ErrorMessages.ImportConfigFailed);
            }

            return spells;
        }

        /// <summary>
        /// Serialize and save a config 
        /// </summary>
        /// <typeparam name="T">Type of config</typeparam>
        /// <param name="config">config to serialize</param>
        /// <param name="fileName">destination file</param>
        public static void SaveConfig<T>(T config, string fileName) where T: ISerilizable {
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


        public static SpellListWrapper? MigrateSpellConfig(SpellListWrapper spellList, string imageDirectory) {
            var fileTypes = new[] { "*.png", "*.jpg", "*.jpeg" };
            var imageNamesPathMap = new Dictionary<string, string>();
            foreach (var fileType in fileTypes) {
                var files = Directory.GetFiles(imageDirectory, fileType, SearchOption.AllDirectories);
                foreach (var file in files) {
                    var fileName = Path.GetFileNameWithoutExtension(file);
                    if (!imageNamesPathMap.TryAdd(fileName, file)) {
                        MessageBox.Show(String.Format(Resources.ErrorMessages.ImageNamesNotUnique, file,
                            imageNamesPathMap[fileName]));
                        return null;
                    }
                }
            }

            var mismatched = new List<Spell>();
            var spellNameUpdatedSpell = new Dictionary<string, Spell>();
            foreach (var spell in spellList.Spells) {
                var spellFileName = Path.GetFileNameWithoutExtension(spell.ImagePath);
                if (imageNamesPathMap.TryGetValue(spellFileName, out var newPath)) {
                    spell.ImagePath = newPath;
                    spellNameUpdatedSpell.Add(spell.Name, spell);
                } else {
                    mismatched.Add(spell);
                }
            }

            var updated = spellList.Spells.Except(mismatched).ToArray();
            var mismatchedByDep = new List<Spell>();
            foreach (var spell in updated) {
                var updatedDeps = new List<Spell>();
                foreach (var dependency in spell.Dependencies) {
                    if (spellNameUpdatedSpell.TryGetValue(dependency.Name, out var updatedSpell)) {
                        updatedDeps.Add(updatedSpell);
                    } else {
                        mismatchedByDep.Add(spell);
                    }
                }

                spell.Dependencies = updatedDeps.ToImmutableArray();
            }

            spellList = new SpellListWrapper(updated.Except(mismatched).Except(mismatchedByDep));
            var msg = new StringBuilder();
            foreach (var spell in mismatched) {
                msg.AppendLine($"{spell.Name} => {spell.ImagePath}");
            }

            var depMsg = new StringBuilder();
            foreach (var spell in mismatchedByDep) {
                depMsg.AppendLine($"{spell.Name} depends on:");
                foreach (var dependency in spell.Dependencies) {
                    depMsg.AppendLine($"\t {dependency.Name} => {dependency.ImagePath}");
                }
            }

            if (msg.Length > 0 || depMsg.Length > 0) {
                MessageBox.Show(Resources.ErrorMessages.MismatchedSpells + Environment.NewLine + msg +
                                Environment.NewLine + Environment.NewLine +
                                Resources.ErrorMessages.CorruptDependencies + Environment.NewLine + depMsg +
                                Environment.NewLine + Resources.Messages.SaveMigratedConfig);
            } else {
                MessageBox.Show(Resources.Messages.MigrationSuccess + Environment.NewLine +
                                Resources.Messages.SaveMigratedConfig);
            }

            return spellList;
        }
    }
}
