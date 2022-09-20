using System;
using System.Collections.Immutable;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DOS2Randomizer.DataStructures;
using DOS2Randomizer.UI.Components;
using DOS2Randomizer.Util;

namespace DOS2Randomizer.UI {
    /// <summary>
    /// Form used to create or adapt MatchConfigurations
    /// </summary>
    public partial class ConfigCreator : BaseWindow {
        #region Fields

        private MatchConfig _matchConfig;
        private readonly PdfVisualizer _levelImportanceVisualizer;
        private readonly PdfVisualizer _attributeImportanceVisualizer;
        private readonly PdfVisualizer _skillPointImportanceVisualizer;
        private readonly PdfVisualizer _skillPointDiffImportanceVisualizer;
        private readonly SaveManager _saveManager;

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
                unlimShuffles.DataBindings.Clear();
                unlimShuffles.DataBindings.Add(nameof(unlimShuffles.Checked), _matchConfig,
                    nameof(_matchConfig.UnlimitedShuffles), false, DataSourceUpdateMode.OnPropertyChanged);
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
            _saveManager = new SaveManager();
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
                xRange: 40,
                levelSamples: new []{1, 6, 11, 16, 21}
            );

            _skillPointImportanceVisualizer = new PdfVisualizer (
                function: (x, std) => Logic.SpellChooser.Gaussian(x, Logic.SpellChooser.SkillPointFactor * std),
                xLabel: "Skill Points Difference",
                xRange: 15,
                levelSamples: new []{1, 6, 11, 16, 21}
            );

            _skillPointDiffImportanceVisualizer = new PdfVisualizer (
                function: (x, std) => Logic.SpellChooser.Gaussian(x, Logic.SpellChooser.SkillPointFactor * std),
                xLabel: "Skill points to spend",
                xRange: 10,
                levelSamples: new []{1, 6, 11, 16, 21}
            );

            pdfLayout.Controls.Add(_levelImportanceVisualizer);
            pdfLayout.Controls.Add(_attributeImportanceVisualizer);
            pdfLayout.Controls.Add(_skillPointImportanceVisualizer);
            pdfLayout.Controls.Add(_skillPointDiffImportanceVisualizer);
        }

        private void SaveConfig(string file) {
            ConfigUtils.OverwritePlayerSpells(Config, Config.Spells);
            Config.SpellWeights = new ImportanceValues(_levelImportanceVisualizer.Std,
                _attributeImportanceVisualizer.Std, _skillPointImportanceVisualizer.Std,
                _skillPointDiffImportanceVisualizer.Std);
            FileIo.SaveConfig(Config, file);
        }

        #region event handlers
        private void SaveButton_Click(object sender, System.EventArgs e) {
            if (_saveManager.GetNewPath() is {} file) {
                SaveConfig(file);
            }
        }

        private void importSpells_Click(object sender, EventArgs e) {
            if (ConfigUtils.LoadConfigOrMigrate<SpellListWrapper>(out _) is { } s) {
                Spells = s.Spells.ToArray();
            }
        }

        private void importConfig_Click(object sender, EventArgs e) {
            if (ConfigUtils.LoadConfigOrMigrate<MatchConfig>(out var configPath) is { } config) {
                Config = config;
                _saveManager.Path = configPath;
            }
        }

        private void ConfigCreator_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.S && e.Modifiers == Keys.Control && _saveManager.Path is { } file) {
                SaveConfig(file);
            }
        }

        private void unlimShuffles_CheckedChanged(object sender, EventArgs e) {
            levelSpecificTable.ShufflesEnabled = !((Components.CheckBox)sender).Checked;
        }

        #endregion
    }
}
