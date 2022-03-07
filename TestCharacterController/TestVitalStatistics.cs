using NUnit.Framework;
using CharacterLib;
using System;
using System.Text;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
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


            Assert.That(stats.Strength.Mod, Is.EqualTo(5));
            Assert.That(stats.Dexterity.Mod, Is.EqualTo(4));
            Assert.That(stats.Constitution.Mod, Is.EqualTo(4));
            Assert.That(stats.Intelligence.Mod, Is.EqualTo(3));
            Assert.That(stats.Wisdom.Mod, Is.EqualTo(3));
            Assert.That(stats.Charisma.Mod, Is.EqualTo(2));

            Assert.That(stats2.Strength.Mod, Is.EqualTo(2));
            Assert.That(stats2.Dexterity.Mod, Is.EqualTo(1));
            Assert.That(stats2.Constitution.Mod, Is.EqualTo(1));
            Assert.That(stats2.Intelligence.Mod, Is.EqualTo(0));
            Assert.That(stats2.Wisdom.Mod, Is.EqualTo(0));

        }

        [Test]
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


            Assert.That(stats.Strength.Mod, Is.EqualTo(-1));
            Assert.That(stats.Dexterity.Mod, Is.EqualTo(-1));
            Assert.That(stats.Constitution.Mod, Is.EqualTo(-2));
            Assert.That(stats.Intelligence.Mod, Is.EqualTo(-2));
            Assert.That(stats.Wisdom.Mod, Is.EqualTo(-3));
            Assert.That(stats.Charisma.Mod, Is.EqualTo(-3));

            Assert.That(stats2.Strength.Mod, Is.EqualTo(-4));
            Assert.That(stats2.Dexterity.Mod, Is.EqualTo(-4));
            Assert.That(stats2.Constitution.Mod, Is.EqualTo(-5));

        }

        [Test]
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

            Assert.That(total.Strength.Score, Is.EqualTo(9));
            Assert.That(total.Dexterity.Score, Is.EqualTo(11));
            Assert.That(total.Constitution.Score, Is.EqualTo(8));
            Assert.That(total.Intelligence.Score, Is.EqualTo(12));
            Assert.That(total.Wisdom.Score, Is.EqualTo(10));

        }

        [Test]
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

            Assert.AreEqual(stats, stats2);
            Assert.AreNotEqual(total, stats2);
        }

        [Test]
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

            //string repr = "Strength: 8 [-1]" + Environment.NewLine;
            //repr += "Dexterity: 12 [+1]" + Environment.NewLine;
            //repr += "Constitution: 10 [+0]" + Environment.NewLine;
            //repr += "Intelligence: 1 [-5]" + Environment.NewLine;
            //repr += "Wisdom: 20 [+5]" + Environment.NewLine;
            //repr += "Charisma: 10 [+0]" + Environment.NewLine;
       
            Assert.AreEqual(sb.ToString(), stats.ToString());

           
        }


    }
}