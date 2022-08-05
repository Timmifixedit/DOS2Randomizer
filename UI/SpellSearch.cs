using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DOS2Randomizer.DataStructures;

namespace DOS2Randomizer.UI {
    class SpellSearch : LabeledString {
        public ISpellCollection ManagedCollection { get; set; }

        public bool CaseSensitive { get; set; }

        public Spell[] AllSpells {
            get => _spells;
            set {
                _spells = value;
                if (ManagedCollection != null) {
                    ManagedCollection.SpellCollection = _spells;
                }
            }

        }

        private Spell[] _spells;

        private string ManageCase(string s) {
            return CaseSensitive ? s : s.ToLower();
        }

        private void Search(string searchString) {
            ManagedCollection.SpellCollection = AllSpells
                ?.Where(spell => ManageCase(spell.Name).Contains(ManageCase(searchString))).ToArray();
        }

        public SpellSearch() {
            OnValueChanged = Search;
        }
    }
}
