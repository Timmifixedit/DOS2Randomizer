namespace DOS2Randomizer.DataStructures {
    public enum Attribute {
        Strength,
        Int,
        Finesse,
        Con,
        Mem,
        Wit,
        None
    }

    public class Player {
        public enum SkillType {
            Melee,
            Archer,
            Shield,
            Dagger
        }

        public int Level { get; set; }
        public string Name { get; set; }
        public Spell[] KnownSpells { get; set; }
        public Spell[] EquippedSpells { get; set; }

    }
}
