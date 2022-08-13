using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOS2Randomizer.DataStructures;

namespace DOS2Randomizer.Logic {
    internal static class RandomExtension {
        public static IEnumerable<T> ChooseRandom<T>(this IEnumerable<T> source, int num) {
            var rng = new Random();
            return source.OrderBy(arg => rng.Next()).Take(num).ToList();
        }
    }

    public class SpellChooser {
        private readonly IMatchProperties _matchConfig;
        private readonly IConstPlayer _player;
        private readonly int _numSpellsToGenerate;
        public SpellChooser(IMatchProperties matchConfig, IConstPlayer player) {
            _matchConfig = matchConfig;
            _numSpellsToGenerate = _matchConfig.N;
            _player = player;
        }

        public IEnumerable<IConstSpell> GetSpells() {
            // @TODO this is only a dummy implementation
            return _matchConfig.CSpells.Except(_player.CKnownSpells).ChooseRandom(_numSpellsToGenerate);
        }
    }
}
