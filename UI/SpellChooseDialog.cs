﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DOS2Randomizer.DataStructures;

namespace DOS2Randomizer.UI {
    public partial class SpellChooseDialog : Form {

        public Action<IEnumerable<IConstSpell>>? OnConfirm;

        public string FromListName {
            get => fromList.Label;
            set => fromList.Label = value;
        }

        public string ToListName {
            get => toList.Label;
            set => toList.Label = value;
        }

        public SpellChooseDialog(IEnumerable<IConstSpell> source, IEnumerable<IConstSpell> destination) {
            InitializeComponent();
            fromList.Spells = source;
            toList.Spells = destination;
            fromList.OnImageClick = spell => { MoveSpellTo(spell, fromList, toList); };
            toList.OnImageClick = spell => { MoveSpellTo(spell, toList, fromList); };
        }

        public static void MoveSpellTo(IConstSpell spell, ISpellCollection<IConstSpell> source, ISpellCollection<IConstSpell> destination) {
            destination.Spells = (destination.Spells ?? Array.Empty<IConstSpell>()).Append(spell).ToArray();
            source.Spells = source.Spells?.Except(new[] {spell}).ToArray();
        }

        private void confirm_Click(object sender, EventArgs e) {
            OnConfirm?.Invoke(toList.Spells ?? Array.Empty<Spell>());
            this.Close();
        }
    }
}
