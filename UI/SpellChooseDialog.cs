using System;
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

        public ValueChangedEvent<Spell[]>? OnConfirm;
        public SpellChooseDialog(Spell[] spells) {
            InitializeComponent();
            fromList.Spells = (Spell[]) spells.Clone();
            fromList.OnImageClick = spell => { MoveSpellTo(spell, fromList, selectionList); };
            selectionList.OnImageClick = spell => { MoveSpellTo(spell, fromList, selectionList); };
        }

        private void MoveSpellTo(Spell spell, ISpellCollection source, ISpellCollection destination) {
            destination.Spells = (destination.Spells ?? Array.Empty<Spell>()).Append(spell).ToArray();
            source.Spells = source.Spells?.Except(new[] {spell}).ToArray();
        }

        private void confirm_Click(object sender, EventArgs e) {
            OnConfirm?.Invoke(selectionList.Spells ?? Array.Empty<Spell>());
            this.Close();
        }
    }
}
