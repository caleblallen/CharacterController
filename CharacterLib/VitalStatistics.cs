using System;
using System.Collections.Generic;
using System.Text;

namespace CharacterLib
{
    public class VitalStatistics
    {
        public Stat Strength { get; set; }
        public Stat Dexterity { get; set; }
        public Stat Constitution { get; set; }
        public Stat Intelligence { get; set; }
        public Stat Wisdom { get; set; }
        public Stat Charisma { get; set; }

        public VitalStatistics(int strength, int dexterity, int constitution, int intelligence, int wisdom, int charisma)
        {
            Strength = new Stat { Score = strength };
            Dexterity = new Stat { Score = dexterity };
            Constitution = new Stat { Score = constitution };
            Intelligence = new Stat { Score = intelligence };
            Wisdom = new Stat { Score = wisdom };
            Charisma = new Stat { Score = charisma };
        }

        public VitalStatistics() { }

        public static VitalStatistics operator +(VitalStatistics a, VitalStatistics b)
        {
            return new VitalStatistics()
            {
                Strength = a.Strength + b.Strength,
                Dexterity = a.Dexterity + b.Dexterity,
                Constitution = a.Constitution + b.Constitution,
                Intelligence = a.Intelligence + b.Intelligence,
                Wisdom = a.Wisdom + b.Wisdom,
                Charisma = a.Charisma + b.Charisma,
            };
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
                return false;
            else
                return this.Equals(obj as VitalStatistics);
        }

        public bool Equals(VitalStatistics other)
        {
            return Strength.Equals(other.Strength) &&
                Dexterity.Equals(other.Dexterity) &&
                Constitution.Equals(other.Constitution) &&
                Intelligence.Equals(other.Intelligence) &&
                Wisdom.Equals(other.Wisdom) &&
                Charisma.Equals(other.Charisma);
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendFormat("Strength: {0} [{1}{2}]{3}", Strength.Score, (Strength.Mod < 0) ? "" : "+", Strength.Mod, Environment.NewLine);
            sb.AppendFormat("Dexterity: {0} [{1}{2}]{3}", Dexterity.Score, (Dexterity.Mod < 0) ? "" : "+", Dexterity.Mod, Environment.NewLine);
            sb.AppendFormat("Constitution: {0} [{1}{2}]{3}", Constitution.Score, (Constitution.Mod < 0) ? "" : "+", Constitution.Mod, Environment.NewLine);
            sb.AppendFormat("Intelligence: {0} [{1}{2}]{3}", Intelligence.Score, (Intelligence.Mod < 0) ? "" : "+", Intelligence.Mod, Environment.NewLine);
            sb.AppendFormat("Wisdom: {0} [{1}{2}]{3}", Wisdom.Score, (Wisdom.Mod < 0) ? "" : "+", Wisdom.Mod, Environment.NewLine);
            sb.AppendFormat("Charisma: {0} [{1}{2}]{3}", Charisma.Score, (Charisma.Mod < 0) ? "" : "+", Charisma.Mod, Environment.NewLine);
            return sb.ToString();
        }
    }

}
