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

        public ValueChangedEvent<Spell[]> OnConfirm;
        public SpellChooseDialog([DisallowNull]Spell[] spells) {
            fromList.Spells = spells;
            fromList.OnImageClick = spell => { MoveSpellTo(spell, selectionList); };
            selectionList.OnImageClick = spell => { MoveSpellTo(spell, fromList); };
            InitializeComponent();
        }

        private void MoveSpellTo(Spell spell, ISpellCollection destination) {
            destination.SpellCollection = (selectionList.Spells ?? new Spell[0]).Append(spell).ToArray();
        }

        private void confirm_Click(object sender, EventArgs e) {
            OnConfirm?.Invoke(selectionList.Spells);
        }
    }
}
