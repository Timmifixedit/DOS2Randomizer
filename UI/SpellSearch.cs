using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DOS2Randomizer.DataStructures;

namespace DOS2Randomizer.UI {
    class SpellSearch : LabeledString {
        private Spell[]? _spells;
        public ISpellCollection? ManagedCollection { get; set; }

        public bool CaseSensitive { get; set; }

        public Spell[]? AllSpells {
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
            if (ManagedCollection is not  null && AllSpells is not null) {
                ManagedCollection.Spells = AllSpells
                    .Where(spell => ManageCase(spell.Name).Contains(ManageCase(searchString))).ToArray();
            }
        }

        public SpellSearch() {
            OnValueChanged = Search;
        }
    }
}
