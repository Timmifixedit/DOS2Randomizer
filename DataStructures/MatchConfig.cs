﻿using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace DOS2Randomizer.DataStructures {
    /// <summary>
    /// Read-only view of properties of MatchConfig which are of interest when drawing new spells
    /// </summary>
    public interface IMatchProperties {
        public int MaxNumMemSlots { get; set; }

        /// <summary>
        /// Number of spells to choose from when drawing new spells
        /// </summary>
        public int N { get; }

        /// <summary>
        /// Number of spells to choose from spell selection
        /// </summary>
        public int K { get; }

        /// <summary>
        /// Specifies number of additional spells, rerolls and shuffles at each level
        /// </summary>
        public ImmutableArray<OnLevelUp> LevelSpecificEvents { get; }

        /// <summary>
        /// Read-only view of Spells
        /// </summary>
        [JsonIgnore]
        public ImmutableArray<IConstSpell> CSpells { get; }
    }

    /// <summary>
    /// Read-only view of MatchConfig which adds the config name and the participating players to
    /// IMatchProperties. Players can be reassigned
    /// </summary>
    public interface IConstMatchConfig : IMatchProperties {
        public string Name { get; }

        /// <summary>
        /// participating players
        /// </summary>
        public ImmutableArray<IMutablePlayer> Players { get; set; }

    }

    /// <summary>
    /// Contains all information about a match including participating players and available spells
    /// </summary>
    public class MatchConfig : IConstMatchConfig, ISerilizable {
        public const int MaxNumPlayers = 4;
        public const int MaxLevel = 21;
        public string Name { get; set; }
        public int MaxNumMemSlots { get; set; }

        /// <summary>
        /// Number of spells to choose from when drawing new spells
        /// </summary>
        public int N { get; set; }

        /// <summary>
        /// Number of spells to choose from spell selection
        /// </summary>
        public int K { get; set; }

        /// <summary>
        /// Specifies number of additional spells, rerolls and shuffles at each level
        /// </summary>
        public ImmutableArray<OnLevelUp> LevelSpecificEvents { get; set; }

        /// <summary>
        /// Read-only view of Spells
        /// </summary>
        public ImmutableArray<IConstSpell> CSpells => Spells.CastArray<IConstSpell>();

        /// <summary>
        /// all available spells
        /// </summary>
        public ImmutableArray<Spell> Spells { get; set; }

        /// <summary>
        /// participating players
        /// </summary>
        public ImmutableArray<IMutablePlayer> Players { get; set; }

        /// <summary>
        /// Creates a MatchConfig with no players or spells
        /// </summary>
        public MatchConfig() {
            LevelSpecificEvents =
                Enumerable.Range(1, MaxLevel).Select(i => new OnLevelUp(i, 0, 0, 0)).ToImmutableArray();
            Name = "<Match config name>";
            Spells = ImmutableArray<Spell>.Empty;
            Players = ImmutableArray<IMutablePlayer>.Empty;
        }

        [JsonConstructor]
        public MatchConfig(string name, int maxNumMemSlots, int n, int k, ImmutableArray<OnLevelUp> levelSpecificEvents,
            ImmutableArray<Spell> spells, ImmutableArray<Player> players) {
            Name = name;
            MaxNumMemSlots = maxNumMemSlots;
            N = n;
            K = k;
            LevelSpecificEvents = levelSpecificEvents;
            Spells = spells;
            Players = players.CastArray<IMutablePlayer>();
            var missingIcons = SpellListWrapper.MissingIcons(Spells);
            if (missingIcons.Length > 0) {
                throw new FileNotFoundException(
                    Resources.ErrorMessages.InvalidSpellConfig + Environment.NewLine +
                    missingIcons);
            }
        }
    }

}
