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
    /// User control that can manage an ISpellCollection and provide search utility
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public partial class SpellSearchBase<T> : LabeledString where T: IConstSpell {
        public SpellSearchBase() {
            InitializeComponent();
            OnValueChanged = Search;
        }

        private IEnumerable<T>? _spells;
        public ISpellCollection<T>? ManagedCollection { get; set; }

        public bool CaseSensitive { get; set; }

        public IEnumerable<T>? AllSpells {
            get => _spells;
            set {
                _spells = value;
                if (ManagedCollection != null) {
                    ManagedCollection.Spells = _spells;
                }
            }

        }

        private string ManageCase(string s) {
            return CaseSensitive ? s : s.ToLower();
        }

        private void Search(string searchString) {
            if (ManagedCollection is not null && AllSpells is not null) {
                ManagedCollection.Spells = AllSpells
                    .Where(spell => ManageCase(spell.Name).Contains(ManageCase(searchString))).ToArray();
            }
        }
    }
    class SpellSearch : SpellSearchBase<Spell> {}
    class CSpellSearch : SpellSearchBase<IConstSpell> {}
}
