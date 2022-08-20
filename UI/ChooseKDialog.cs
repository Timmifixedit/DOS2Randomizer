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
    /// <summary>
    /// Dialog that requires the user to choose K spells from a randomly generated selection
    /// </summary>
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

        #region fields

        public Action<IEnumerable<IConstSpell>, int>? OnConfirm;
        private int _numToChoose;
        private int _numLeftToChoose;
        private int _numRerolls;
        private readonly Logic.SpellChooser _spellChooser;

        #endregion

        private int NumRerolls {
            get => _numRerolls;
            set {
                _numRerolls = value;
                reroll.Text = String.Format(Resources.Messages.Rerolls, NumRerolls);
            }
        }
        private int NumLeft {
            get => _numLeftToChoose;
            set {
                _numLeftToChoose = value;
                confirm.Enabled = _numLeftToChoose == 0;
                description.Text = String.Format(Resources.Messages.ChooseK, NumLeft);
            }
        }

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="spellChooser">SpellChooser instance used to generate a selection</param>
        /// <param name="numSpellsToChoose">size of spell selection</param>
        /// <param name="numRerolls">number of times a reroll may be performed</param>
        public ChooseKDialog(Logic.SpellChooser spellChooser, int numSpellsToChoose, int numRerolls) {
            InitializeComponent();
            _spellChooser = spellChooser;
            source.Spells = _spellChooser.DrawSpells();
            _numToChoose = Math.Min(numSpellsToChoose, source.Spells.Count());
            NumLeft = _numToChoose;
            NumRerolls = numRerolls;
            source.OnImageClick = spell => {
                if (selection.Spells is null || selection.Spells.Count() < numSpellsToChoose) {
                    --NumLeft;
                    SpellChooseDialog.MoveSpellTo(spell, source, selection);
                }
            };
            selection.OnImageClick = spell => {
                ++NumLeft;
                SpellChooseDialog.MoveSpellTo(spell, selection, source);
            };
        }

        #region event handlers
        private void confirm_Click(object sender, EventArgs e) {
            OnConfirm?.Invoke(selection.Spells ?? Array.Empty<Spell>(), NumRerolls);
            this.Close();
        }

        private void reroll_Click(object sender, EventArgs e) {
            if (NumRerolls > 0) {
                --NumRerolls;
                reroll.Enabled = NumRerolls > 0;
                source.Spells = _spellChooser.DrawSpells();
                selection.Spells = null;
                NumLeft = _numToChoose;
            }
        }

        #endregion
    }
}
