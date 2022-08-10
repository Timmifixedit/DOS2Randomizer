using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DOS2Randomizer.DataStructures;

namespace DOS2Randomizer.UI {
    public partial class ChooseKDialog : Form {

        public Action<IEnumerable<Spell>>? OnConfirm;
        private int _numLeftToChoose;
        public ChooseKDialog(IEnumerable<Spell> chooseFrom, int k) {
            _numLeftToChoose = k;
            InitializeComponent();
            source.Spells = chooseFrom;
            source.OnImageClick = spell => {
                if (selection.Spells is null || selection.Spells.Count() < k) {
                    description.Text = String.Format(Resources.Messages.ChooseK, --_numLeftToChoose);
                    SpellChooseDialog.MoveSpellTo(spell, source, selection);
                }
            };
            selection.OnImageClick = spell => {
                description.Text = String.Format(Resources.Messages.ChooseK, ++_numLeftToChoose);
                SpellChooseDialog.MoveSpellTo(spell, selection, source);
            };
            description.Text = String.Format(Resources.Messages.ChooseK, k);
        }

        private void confirm_Click(object sender, EventArgs e) {
            OnConfirm?.Invoke(selection.Spells ?? Array.Empty<Spell>());
            this.Close();
        }
    }
}
