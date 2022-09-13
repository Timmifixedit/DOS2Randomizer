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
using DOS2Randomizer.UI.Components;

namespace DOS2Randomizer.UI {

    /// <summary>
    /// Dialog for choosing spells from a collection
    /// </summary>
    public partial class SpellChooseDialog : BaseWindow {

        /// <summary>
        /// Event that is triggered when the selection is confirmed
        /// </summary>
        public Action<IEnumerable<IConstSpell>>? OnConfirm;

        /// <summary>
        /// Event that is triggered when the dialog is closed in any way
        /// </summary>
        public Action? OnClose;

        /// <summary>
        /// Label of the list from where spells are drawn
        /// </summary>
        public string FromListName {
            get => fromList.Label;
            set => fromList.Label = value;
        }

        /// <summary>
        /// Label of the list where spells are put into
        /// </summary>
        public string ToListName {
            get => toList.Label;
            set => toList.Label = value;
        }

        /// <summary>
        /// CTor. Both source and destination remained unchanged. Get updates via the OnConfirmEvent
        /// </summary>
        /// <param name="source">source collection of spells</param>
        /// <param name="destination">destination collection of spells</param>
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

        private void SpellChooseDialog_FormClosed(object sender, FormClosedEventArgs e) {
            OnClose?.Invoke();
        }
    }
}
