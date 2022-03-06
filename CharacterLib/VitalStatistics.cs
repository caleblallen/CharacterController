using System;
using System.Collections.Generic;
using System.Text;

namespace CharacterLib
{
    public class VitalStatistics
    {
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }
        public int StrengthModifier { get { return VitalStatistics.ToMod(Strength); } }
        public int DexterityModifier { get { return VitalStatistics.ToMod(Dexterity); } }
        public int ConstitutionModifier { get { return VitalStatistics.ToMod(Constitution); } }
        public int IntelligenceModifier { get { return VitalStatistics.ToMod(Intelligence); } }
        public int WisdomModifier { get { return VitalStatistics.ToMod(Wisdom); } }
        public int CharismaModifier { get { return VitalStatistics.ToMod(Charisma); } }


        public VitalStatistics(int strength, int dexterity, int constitution, int intelligence, int wisdom, int charisma)
        {
            Strength = strength;
            Dexterity = dexterity;
            Constitution = constitution;
            Intelligence = intelligence;
            Wisdom = wisdom;
            Charisma = charisma;
        }

        public VitalStatistics()
        {
        }

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

        private static int ToMod(int stat)
        {
            return (int)Math.Floor(((double)stat - 10.0) / 2.0);
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                VitalStatistics other = (VitalStatistics)obj;
                return Strength == other.Strength &&
                    Dexterity == other.Dexterity &&
                    Constitution == other.Constitution &&
                    Intelligence == other.Intelligence &&
                    Wisdom == other.Wisdom &&
                    Charisma == other.Charisma;
            }
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendFormat("Strength: {0} [{1}{2}]{3}", Strength, (StrengthModifier < 0) ? "" : "+", StrengthModifier, Environment.NewLine);
            sb.AppendFormat("Dexterity: {0} [{1}{2}]{3}", Dexterity, (DexterityModifier < 0) ? "" : "+", DexterityModifier, Environment.NewLine);
            sb.AppendFormat("Constitution: {0} [{1}{2}]{3}", Constitution, (ConstitutionModifier < 0) ? "" : "+", ConstitutionModifier, Environment.NewLine);
            sb.AppendFormat("Intelligence: {0} [{1}{2}]{3}", Intelligence, (IntelligenceModifier < 0) ? "" : "+", IntelligenceModifier, Environment.NewLine);
            sb.AppendFormat("Wisdom: {0} [{1}{2}]{3}", Wisdom, (WisdomModifier < 0) ? "" : "+", WisdomModifier, Environment.NewLine);
            sb.AppendFormat("Charisma: {0} [{1}{2}]{3}", Charisma, (CharismaModifier < 0) ? "" : "+", CharismaModifier, Environment.NewLine);
            return sb.ToString();
        }
    }

}
