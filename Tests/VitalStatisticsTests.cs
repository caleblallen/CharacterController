using System;
using Xunit;
using CharacterLib;
using System.Text;

namespace Tests
{
    public class VitalStatisticsTests
    {

        [Fact]
        public void VitalStatistics_ToMod_ComputesPositiveMods()
        {
            var stats = new VitalStatistics()
            {
                Strength = new Stat() { Score = 20 },
                Dexterity = new Stat() { Score = 19 },
                Constitution = new Stat() { Score = 18 },
                Intelligence = new Stat() { Score = 17 },
                Wisdom = new Stat() { Score = 16 },
                Charisma = new Stat() { Score = 15 }
            };

            var stats2 = new VitalStatistics()
            {
                Strength = new Stat() { Score = 14 },
                Dexterity = new Stat() { Score = 13 },
                Constitution = new Stat() { Score = 12 },
                Intelligence = new Stat() { Score = 11 },
                Wisdom = new Stat() { Score = 10 },
                Charisma = new Stat() { Score = 10 }
            };


            Assert.Equal(5, stats.Strength.Mod);
            Assert.Equal(4, stats.Dexterity.Mod);
            Assert.Equal(4, stats.Constitution.Mod);
            Assert.Equal(3, stats.Intelligence.Mod);
            Assert.Equal(3, stats.Wisdom.Mod);
            Assert.Equal(2, stats.Charisma.Mod);

            Assert.Equal(2, stats2.Strength.Mod);
            Assert.Equal(1, stats2.Dexterity.Mod);
            Assert.Equal(1, stats2.Constitution.Mod);
            Assert.Equal(0, stats2.Intelligence.Mod);
            Assert.Equal(0, stats2.Wisdom.Mod);

        }

        [Fact]
        public void VitalStatistics_ToMod_ComputesNegativeMods()
        {
            var stats = new VitalStatistics()
            {
                Strength = new Stat() { Score = 9 },
                Dexterity = new Stat() { Score = 8 },
                Constitution = new Stat() { Score = 7 },
                Intelligence = new Stat() { Score = 6 },
                Wisdom = new Stat() { Score = 5 },
                Charisma = new Stat() { Score = 4 }
            };

            var stats2 = new VitalStatistics()
            {
                Strength = new Stat() { Score = 3 },
                Dexterity = new Stat() { Score = 2 },
                Constitution = new Stat() { Score = 1 },
                Intelligence = new Stat() { Score = 1 },
                Wisdom = new Stat() { Score = 1 },
                Charisma = new Stat() { Score = 1 }
            };


            Assert.Equal(-1, stats.Strength.Mod);
            Assert.Equal(-1, stats.Dexterity.Mod);
            Assert.Equal(-2, stats.Constitution.Mod);
            Assert.Equal(-2, stats.Intelligence.Mod);
            Assert.Equal(-3, stats.Wisdom.Mod);
            Assert.Equal(-3, stats.Charisma.Mod);

            Assert.Equal(-4, stats2.Strength.Mod);
            Assert.Equal(-4, stats2.Dexterity.Mod);
            Assert.Equal(-5, stats2.Constitution.Mod);

        }

        [Fact]
        public void VitalStatistics_Properties_AddsChildVitalStatistics()
        {
            var stats = new VitalStatistics()
            {
                Strength = new Stat() { Score = 10 },
                Dexterity = new Stat() { Score = 10 },
                Constitution = new Stat() { Score = 10 },
                Intelligence = new Stat() { Score = 10 },
                Wisdom = new Stat() { Score = 10 },
                Charisma = new Stat() { Score = 10 }
            };

            var stats2 = new VitalStatistics()
            {
                Strength = new Stat() { Score = -1 },
                Dexterity = new Stat() { Score = 1 },
                Constitution = new Stat() { Score = -2 },
                Intelligence = new Stat() { Score = 2 },
                Wisdom = new Stat() { Score = 0 },
                Charisma = new Stat() { Score = 0 }
            };

            VitalStatistics total = stats + stats2;

            Assert.Equal(9, total.Strength.Score);
            Assert.Equal(11, total.Dexterity.Score);
            Assert.Equal(8, total.Constitution.Score);
            Assert.Equal(12, total.Intelligence.Score);
            Assert.Equal(10, total.Wisdom.Score);

        }

        [Fact]
        public void VitalStatistics_Equals_SameStatsAreEqual()
        {
            var stats = new VitalStatistics()
            {
                Strength = new Stat() { Score = 10 },
                Dexterity = new Stat() { Score = 9 },
                Constitution = new Stat() { Score = 10 },
                Intelligence = new Stat() { Score = 10 },
                Wisdom = new Stat() { Score = 8 },
                Charisma = new Stat() { Score = 10 }
            };

            var stats2 = new VitalStatistics()
            {
                Strength = new Stat() { Score = 10 },
                Dexterity = new Stat() { Score = 9 },
                Constitution = new Stat() { Score = 10 },
                Intelligence = new Stat() { Score = 10 },
                Wisdom = new Stat() { Score = 8 },
                Charisma = new Stat() { Score = 10 }
            };

            var total = stats + stats2;

            Assert.Equal(stats, stats2);
            Assert.NotEqual(total, stats2);
        }

        [Fact]
        public void VitalStatistics_ToString_ExpectedStringRepresentation()
        {
            var stats = new VitalStatistics()
            {
                Strength = new Stat() { Score = 8 },
                Dexterity = new Stat() { Score = 12 },
                Constitution = new Stat() { Score = 10 },
                Intelligence = new Stat() { Score = 1 },
                Wisdom = new Stat() { Score = 20 },
                Charisma = new Stat() { Score = 10 }
            };

            var sb = new StringBuilder();
            sb.AppendFormat("Strength: 8 [-1]{0}", Environment.NewLine);
            sb.AppendFormat("Dexterity: 12 [+1]{0}", Environment.NewLine);
            sb.AppendFormat("Constitution: 10 [+0]{0}", Environment.NewLine);
            sb.AppendFormat("Intelligence: 1 [-5]{0}", Environment.NewLine);
            sb.AppendFormat("Wisdom: 20 [+5]{0}", Environment.NewLine);
            sb.AppendFormat("Charisma: 10 [+0]{0}", Environment.NewLine);

            Assert.Equal(sb.ToString(), stats.ToString());


        }
    }
}
