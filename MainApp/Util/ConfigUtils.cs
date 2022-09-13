using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Immutable;
using System.IO;
using System.Windows.Forms;
using DOS2Randomizer.DataStructures;

namespace DOS2Randomizer.Util {
    internal static class ConfigUtils {
        public static void OverwritePlayerSpells(MatchConfig config, IEnumerable<Spell> spells) {
            var spellLookup =
                spells.ToImmutableDictionary(spell => spell.Name, spell => (IConstSpell)spell);
            foreach (var player in config.Players) {
                player.CKnownSpells = player.CKnownSpells.Where(spell => spellLookup.ContainsKey(spell.Name))
                    .Select(spell => spellLookup[spell.Name]).ToImmutableArray();
                player.CEquippedSpells = player.CEquippedSpells.Where(spell => spellLookup.ContainsKey(spell.Name))
                    .Select(spell => spellLookup[spell.Name]).ToImmutableArray();
            }
        }

        public static MatchConfig? MigrateMatchConfig(MatchConfig config, string imageDirectory) {
            if (MigrateSpellConfig(new SpellListWrapper(config.Spells), imageDirectory) is { } spellList) {
                config.Spells = spellList.Spells.ToImmutableArray();
                OverwritePlayerSpells(config, config.Spells);
                return config;
            }

            return null;
        }

        public static T? LoadConfigOrMigrate<T>(out string? configPath) where T: class, IConfig{
            configPath = null;
            using var fileChooser = new OpenFileDialog{Filter = Resources.Misc.JsonFilter};
            if (fileChooser.ShowDialog() == DialogResult.OK && FileIo.ImportConfig<T>(fileChooser.FileName) is
                    { } config) {
                if (config.Valid(out _)) {
                    configPath = fileChooser.FileName;
                    return config;
                }

                if (MessageBox.Show(Resources.Messages.PromptForMigration, "", MessageBoxButtons.YesNo) ==
                    DialogResult.Yes) {
                    using var dirChooser = new FolderBrowserDialog { ShowNewFolderButton = false };
                    MessageBox.Show(Resources.Messages.SelectImages);
                    if (dirChooser.ShowDialog() == DialogResult.OK && config.Migrate(dirChooser.SelectedPath) as T is
                            { } migrated) {
                        if (migrated.Valid(out var missing)) {
                            return migrated;
                        } else {
                            MessageBox.Show(Resources.ErrorMessages.InvalidSpellConfig + Environment.NewLine + missing);
                        }
                    }
                }
            }

            return null;
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
                bool success = true;
                foreach (var dependency in spell.Dependencies) {
                    if (spellNameUpdatedSpell.TryGetValue(dependency.Name, out var updatedSpell)) {
                        updatedDeps.Add(updatedSpell);
                    } else {
                        mismatchedByDep.Add(spell);
                        success = false;
                        break;
                    }
                }

                if (success) {
                    spell.Dependencies = updatedDeps.ToImmutableArray();
                }
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
