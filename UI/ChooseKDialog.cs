using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DOS2Randomizer.DataStructures;
using DOS2Randomizer.UI.Components;

namespace DOS2Randomizer.UI {
    /// <summary>
    /// Dialog that requires the user to choose K spells from a randomly generated selection
    /// </summary>
    public partial class ChooseKDialog : BaseWindow {
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
        private readonly int _numToChoose;
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
            Shown += (_, _) => RollDice();
            source.OnImageClick = spell => {
                if (selection.Spells is null || selection.Spells.Count() < _numToChoose) {
                    --NumLeft;
                    SpellChooseDialog.MoveSpellTo(spell, source, selection);
                }
            };
            selection.OnImageClick = spell => {
                ++NumLeft;
                SpellChooseDialog.MoveSpellTo(spell, selection, source);
            };
        }

        public void DisableSpellTransfer() {
            reroll.Enabled = false;
            source.Enabled = false;
            selection.Enabled = false;
        }

        private void EnableSpellTransfer() {
            reroll.Enabled = true;
            source.Enabled = true;
            selection.Enabled = true;
        }

        private async void RollDice() {
            const int maxDelay = 300;
            const int initDelay = 30;
            const double delayFactor = 1.1;
            DisableSpellTransfer();
            for (int delay = initDelay; delay < maxDelay; delay = (int)(delay * delayFactor)) {
                source.Spells = _spellChooser.DrawSpells();
                await Task.Delay(delay);
            }

            EnableSpellTransfer();
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
                selection.Spells = null;
                RollDice();
                NumLeft = _numToChoose;
            }
        }

        #endregion
    }
}
