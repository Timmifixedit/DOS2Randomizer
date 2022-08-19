using System;
using System.Collections.Immutable;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DOS2Randomizer.DataStructures;
using DOS2Randomizer.Util;

namespace DOS2Randomizer.UI {
    /// <summary>
    /// Form used to create or adapt MatchConfigurations
    /// </summary>
    public partial class ConfigCreator : Form {
        #region Fields

        private MatchConfig _matchConfig;
        private PdfVisualizer _levelImportanceVisualizer;
        private PdfVisualizer _attributeImportanceVisualizer;
        private PdfVisualizer _skillPointImportanceVisualizer;

        private MatchConfig Config {
            get => _matchConfig;
            set {
                _matchConfig = value;
                Spells = _matchConfig.Spells.ToArray();
                levelSpecificTable.LevelEvents = _matchConfig.LevelSpecificEvents.ToArray();
                n.Value = _matchConfig.N;
                k.Value = _matchConfig.K;
                configName.Value = _matchConfig.Name;
                memSlots.Value = _matchConfig.MaxNumMemSlots;
                _levelImportanceVisualizer.Std = _matchConfig.SpellWeights.Level;
                _attributeImportanceVisualizer.Std = _matchConfig.SpellWeights.Attribute;
                _skillPointImportanceVisualizer.Std = _matchConfig.SpellWeights.SkillPoints;
            }
        }

        private Spell[] Spells {
            get => _matchConfig.Spells.ToArray();
            set {
                _matchConfig.Spells = value.ToImmutableArray();
                spellDesignPanel1.AllSpells = Spells;
                spellSearch.AllSpells = Spells;
            }
        }

        #endregion
        public ConfigCreator() {
            InitializeComponent();
            spellList.OnImageClick = spell => spellDesignPanel1.Spell = spell;
            _matchConfig = new MatchConfig();
            configName.OnValueChanged = value => _matchConfig.Name = value;
            memSlots.OnValueChanged = value => _matchConfig.MaxNumMemSlots = value;
            n.OnValueChanged = value => _matchConfig.N = value;
            k.OnValueChanged = value => _matchConfig.K = value;
            levelSpecificTable.LevelEvents = _matchConfig.LevelSpecificEvents.ToArray();

            _levelImportanceVisualizer = new PdfVisualizer (
                function: (x, std) => Logic.SpellChooser.Gaussian(x, Logic.SpellChooser.LevelFactor * std),
                xLabel: "Level Difference",
                xRange: MatchConfig.MaxLevel
            );

            _attributeImportanceVisualizer = new PdfVisualizer (
                function:(x, std) => Logic.SpellChooser.Gaussian(x, Logic.SpellChooser.AttributeFactor * std),
                xLabel: "Attribute Difference",
                xRange: 40
            );

            _skillPointImportanceVisualizer = new PdfVisualizer (
                function: (x, std) => Logic.SpellChooser.Gaussian(x, Logic.SpellChooser.SkillPointFactor * std),
                xLabel: "Skill Points Difference",
                xRange: 15
            );

            pdfLayout.Controls.Add(_levelImportanceVisualizer);
            pdfLayout.Controls.Add(_attributeImportanceVisualizer);
            pdfLayout.Controls.Add(_skillPointImportanceVisualizer);
        }

        #region event handlers
        private void SaveButton_Click(object sender, System.EventArgs e) {
            using var fileChooser = new SaveFileDialog { DefaultExt = Resources.Misc.JsonExtension, AddExtension = true };
            if (fileChooser.ShowDialog() == DialogResult.OK) {
                var spellLookup =
                    Config.Spells.ToImmutableDictionary(spell => spell.ImagePath, spell => (IConstSpell)spell);
                foreach (var player in Config.Players) {
                    player.CKnownSpells = player.CKnownSpells.Where(spell => spellLookup.ContainsKey(spell.ImagePath))
                        .Select(spell => spellLookup[spell.ImagePath]).ToImmutableArray();
                    player.CEquippedSpells = player.CEquippedSpells.Where(spell => spellLookup.ContainsKey(spell.ImagePath))
                        .Select(spell => spellLookup[spell.ImagePath]).ToImmutableArray();
                }

                Config.SpellWeights = new ImportanceValues(_levelImportanceVisualizer.Std,
                    _attributeImportanceVisualizer.Std, _skillPointImportanceVisualizer.Std);
                FileIo.SaveConfig(Config, fileChooser.FileName);
            }
        }

        private void import_Click(object sender, EventArgs e) {
            using var fileChooser = new OpenFileDialog { Filter = Resources.Misc.JsonFilter };
            if (fileChooser.ShowDialog() == DialogResult.OK &&
                FileIo.ImportConfig<SpellListWrapper>(fileChooser.FileName) is { } s) {
                Spells = s.Spells.ToArray();
            }
        }

        private void importButton_Click(object sender, EventArgs e) {
            using var fileChooser = new OpenFileDialog { Filter = Resources.Misc.JsonFilter };
            if (fileChooser.ShowDialog() == DialogResult.OK &&
                FileIo.ImportConfig<MatchConfig>(fileChooser.FileName) is { } config) {
                Config = config;
            }
        }

        #endregion
    }
}
