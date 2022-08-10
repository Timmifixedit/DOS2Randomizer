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
        #region Hax

        // Hax to disable close button. Stolen from https://stackoverflow.com/questions/7301825/how-to-hide-only-the-close-x-button/7301828#7301828
        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams {
            get {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }

        #endregion

        public Action<IEnumerable<Spell>>? OnConfirm;
        private int _numLeftToChoose;

        private int NumLeft {
            get => _numLeftToChoose;
            set {
                _numLeftToChoose = value;
                confirm.Enabled = _numLeftToChoose == 0;
            }
        }
        public ChooseKDialog(IEnumerable<Spell> chooseFrom, int k) {
            InitializeComponent();
            NumLeft = k;
            source.Spells = chooseFrom;
            source.OnImageClick = spell => {
                if (selection.Spells is null || selection.Spells.Count() < k) {
                    description.Text = String.Format(Resources.Messages.ChooseK, --NumLeft);
                    SpellChooseDialog.MoveSpellTo(spell, source, selection);
                }
            };
            selection.OnImageClick = spell => {
                description.Text = String.Format(Resources.Messages.ChooseK, ++NumLeft);
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
