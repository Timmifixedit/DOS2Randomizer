using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DOS2Randomizer.DataStructures;
using DOS2Randomizer.Util;

namespace DOS2Randomizer.UI {
    public partial class ConfigCreator : Form {
        #region Fields

        private MatchConfig _matchConfig;

        private MatchConfig Config {
            get => _matchConfig;
            set {
                _matchConfig = value;
                Spells = _matchConfig.Spells;
                levelSpecificTable.LevelEvents = _matchConfig.LevelSpecificEvents;
                n.Value = _matchConfig.N;
                k.Value = _matchConfig.K;
                configName.Value = _matchConfig.Name;
                memSlots.Value = _matchConfig.MaxNumMemSlots;

            }
        }

        private Spell[] Spells {
            get => _matchConfig.Spells;
            set {
                _matchConfig.Spells = value;
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
            levelSpecificTable.LevelEvents = _matchConfig.LevelSpecificEvents;
        }

        private void SaveButton_Click(object sender, System.EventArgs e) {
            using var fileChooser = new SaveFileDialog {DefaultExt = Resources.Misc.JsonExtension, AddExtension = true};
            if (fileChooser.ShowDialog() == DialogResult.OK) {
                FileIo.SaveConfig(Config, fileChooser.FileName);
            }
        }

        private void import_Click(object sender, EventArgs e) {
            using var fileChooser = new OpenFileDialog{Filter = Resources.Misc.JsonFilter};
            if (fileChooser.ShowDialog() == DialogResult.OK &&
                FileIo.ImportConfig<Spell[]>(fileChooser.FileName) is {} s) {
                Spells = s;
            }
        }

        private void importButton_Click(object sender, EventArgs e) {
            using var fileChooser = new OpenFileDialog{Filter = Resources.Misc.JsonFilter};
            if (fileChooser.ShowDialog() == DialogResult.OK &&
                FileIo.ImportConfig<MatchConfig>(fileChooser.FileName) is { } config) {
                Config = config;
            }
        }
    }
}
