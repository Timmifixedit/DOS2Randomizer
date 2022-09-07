using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DOS2Randomizer.DataStructures;
using DOS2Randomizer.UI.Components;
using DOS2Randomizer.Util;
using MessageBox = System.Windows.Forms.MessageBox;

namespace DOS2Randomizer.UI {

    /// <summary>
    /// Form that is used to create and configure spells
    /// </summary>
    public partial class SpellConfigurator : BaseWindow {
        private Spell[]? _spells;
        private readonly SaveManager _saveManager;

        private Spell[] Spells {
            get => _spells ?? Array.Empty<Spell>();
            set {
                _spells = value;
                spellDesignPanel.AllSpells = _spells;
                search.AllSpells = _spells;
            }
        }
        public SpellConfigurator() {
            InitializeComponent();
            _saveManager = new SaveManager();
            spellList.OnImageClick = spell => { spellDesignPanel.Spell = spell; };
        }

        private void import_Click(object sender, EventArgs e) {
            if (ConfigUtils.LoadConfigOrMigrate<SpellListWrapper>(out var configPath) is { } spells) {
                Spells = spells.Spells.ToArray();
                _saveManager.Path = configPath;
            }
        }

        private void save_Click(object sender, EventArgs e) {
            if (spellList.Spells is null) {
                MessageBox.Show(Resources.ErrorMessages.NoSpells);
                return;
            }

            if (_saveManager.GetNewPath() is { } file) {
                FileIo.SaveConfig(new SpellListWrapper(Spells), file);
            }
        }

        private void create_Click(object sender, EventArgs e) {
            using var dirChooser = new FolderBrowserDialog {ShowNewFolderButton = false};
            if (dirChooser.ShowDialog() == DialogResult.OK) {
                var files = Directory.GetFiles(dirChooser.SelectedPath, "*png", SearchOption.AllDirectories);
                foreach (var file in files) {
                    System.Diagnostics.Debug.WriteLine(file);
                }

                Spells = files.Select(imageFile => new Spell(Resources.Misc.DefaultSpellName, imageFile)).ToArray();
            }
        }

        private void remove_Click(object sender, EventArgs e) {
            var spell = spellDesignPanel.Spell;
            if (spell is null) {
                return;
            }

            var confirmed = MessageBox.Show(String.Format(Resources.Messages.RemoveSpell, spell.Name), "",
                MessageBoxButtons.YesNo);
            if (confirmed == DialogResult.Yes) {
                Spells = Spells.Except(new[] { spell }).ToArray();
                foreach (var spell1 in Spells) {
                    spell1.Dependencies = spell1.Dependencies.Except(new[] { spell }).ToImmutableArray();
                }
            }
        }

        private void add_Click(object sender, EventArgs e) {
            using var fileChooser = new OpenFileDialog { Filter = Resources.Misc.ImageFilter };
            if (fileChooser.ShowDialog() == DialogResult.OK) {
                var newSpell = new Spell(Resources.Misc.DefaultSpellName, fileChooser.FileName);
                Spells = Spells.Concat(new[] { newSpell }).ToArray();
            }
        }

        private void SpellConfigurator_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.S && e.Modifiers == Keys.Control && _saveManager.Path is { } file) {
                FileIo.SaveConfig(new SpellListWrapper(Spells), file);
            }
        }
    }
}
