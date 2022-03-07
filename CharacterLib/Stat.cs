using System;
using System.Collections.Generic;
using System.Text;

namespace CharacterLib
{
    public class Stat : IEquatable<Stat>
    {
        public int Score { get; set; }
        public int Mod {
            get
            {
                return (int)Math.Floor(((double)Score - 10.0) / 2.0);
            }
        }
        public override bool Equals(object obj) => this.Equals(obj as Stat);
        public bool Equals(Stat stat)
        {
            return Score == stat.Score;
        }

        public override int GetHashCode()
        {
            return Score.GetHashCode();
        }

        public static Stat operator +(Stat a, Stat b)
        {
            return new Stat()
            {
                Score = a.Score + b.Score
            };
        }
    }
}
