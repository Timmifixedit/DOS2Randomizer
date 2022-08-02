﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DOS2Randomizer.DataStructures;

namespace DOS2Randomizer.UI {
    public partial class LevelSpecificTable : UserControl {
        private OnLevelUp[] _levelEvents;
        private const int MaxLevel = 20;
        public LevelSpecificTable() {
            InitializeComponent();
            _levelEvents = Enumerable.Range(1, MaxLevel).Select(i => new OnLevelUp(i, 0, 0, 0)).ToArray();
            dataGridView.DataSource = _levelEvents;
            dataGridView.Columns[0].HeaderCell.Value = "Level";
            dataGridView.Columns[1].HeaderCell.Value = "New Spells";
            dataGridView.Columns[2].HeaderCell.Value = "New Rerolls";
            dataGridView.Columns[3].HeaderCell.Value = "New Shuffles";
        }
    }
}
