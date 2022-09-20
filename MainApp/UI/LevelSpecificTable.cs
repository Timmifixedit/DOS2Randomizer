using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DOS2Randomizer.DataStructures;
using DOS2Randomizer.UI.Components;

namespace DOS2Randomizer.UI {

    /// <summary>
    /// User control that provides a table for designing level specific settings
    /// </summary>
    public partial class LevelSpecificTable : BaseControl {
        private OnLevelUp[] _levelEvents = null!;
        private bool _shufflesEnabled = true;
        public OnLevelUp[] LevelEvents {
            get => _levelEvents;
            set {
                _levelEvents = value;
                dataGridView.DataSource = _levelEvents;
            }
        }
        public LevelSpecificTable() {
            InitializeComponent();
            LevelEvents = Enumerable.Range(1, MatchConfig.MaxLevel).Select(i => new OnLevelUp(i, 0, 0, 0)).ToArray();
            dataGridView.Columns[0].HeaderCell.Value = "Level";
            dataGridView.Columns[1].HeaderCell.Value = "New Spells";
            dataGridView.Columns[2].HeaderCell.Value = "New Rerolls";
            dataGridView.Columns[3].HeaderCell.Value = "New Shuffles";
        }

        public override DesignType Design {
            get => base.Design;
            set {
                base.Design = value;
                dataGridView.Columns[0].DefaultCellStyle.BackColor = UI.Design.Get(value).BackColor;
                ShufflesEnabled = ShufflesEnabled;
            }
        }

        public bool ShufflesEnabled {
            get => _shufflesEnabled;
            set {
                _shufflesEnabled = value;
                dataGridView.Columns[3].ReadOnly = !_shufflesEnabled;
                var design = UI.Design.Get(Design);
                dataGridView.Columns[3].DefaultCellStyle.BackColor =
                    _shufflesEnabled ? design.EditBackColor : design.DisabledBackColor;
                dataGridView.Columns[3].DefaultCellStyle.ForeColor =
                    _shufflesEnabled ? design.TextColor : design.DisabledTextColor;
            }
        }
    }
}
