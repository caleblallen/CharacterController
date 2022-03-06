using NUnit.Framework;
using CharacterLib;
using System;

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
                Strength = 20,
                Dexterity = 19,
                Constitution = 18,
                Intelligence = 17,
                Wisdom = 16,
                Charisma = 15
            };

            var stats2 = new VitalStatistics()
            {
                Strength = 14,
                Dexterity = 13,
                Constitution = 12,
                Intelligence = 11,
                Wisdom = 10,
                Charisma = 10
            };


            Assert.That(stats.StrengthModifier, Is.EqualTo(5));
            Assert.That(stats.DexterityModifier, Is.EqualTo(4));
            Assert.That(stats.ConstitutionModifier, Is.EqualTo(4));
            Assert.That(stats.IntelligenceModifier, Is.EqualTo(3));
            Assert.That(stats.WisdomModifier, Is.EqualTo(3));
            Assert.That(stats.CharismaModifier, Is.EqualTo(2));

            Assert.That(stats2.StrengthModifier, Is.EqualTo(2));
            Assert.That(stats2.DexterityModifier, Is.EqualTo(1));
            Assert.That(stats2.ConstitutionModifier, Is.EqualTo(1));
            Assert.That(stats2.IntelligenceModifier, Is.EqualTo(0));
            Assert.That(stats2.WisdomModifier, Is.EqualTo(0));

        }

        [Test]
        public void VitalStatistics_ToMod_ComputesNegativeMods()
        {
            var stats = new VitalStatistics()
            {
                Strength = 9,
                Dexterity = 8,
                Constitution = 7,
                Intelligence = 6,
                Wisdom = 5,
                Charisma = 4
            };

            var stats2 = new VitalStatistics()
            {
                Strength = 3,
                Dexterity = 2,
                Constitution = 1,
                Intelligence = 1,
                Wisdom = 1,
                Charisma = 1
            };


            Assert.That(stats.StrengthModifier, Is.EqualTo(-1));
            Assert.That(stats.DexterityModifier, Is.EqualTo(-1));
            Assert.That(stats.ConstitutionModifier, Is.EqualTo(-2));
            Assert.That(stats.IntelligenceModifier, Is.EqualTo(-2));
            Assert.That(stats.WisdomModifier, Is.EqualTo(-3));
            Assert.That(stats.CharismaModifier, Is.EqualTo(-3));

            Assert.That(stats2.StrengthModifier, Is.EqualTo(-4));
            Assert.That(stats2.DexterityModifier, Is.EqualTo(-4));
            Assert.That(stats2.ConstitutionModifier, Is.EqualTo(-5));

        }

        [Test]
        public void VitalStatistics_Properties_AddsChildVitalStatistics()
        {
            var stats = new VitalStatistics()
            {
                Strength = 10,
                Dexterity = 10,
                Constitution = 10,
                Intelligence = 10,
                Wisdom = 10,
                Charisma = 10
            };

            var stats2 = new VitalStatistics()
            {
                Strength = -1,
                Dexterity = 1,
                Constitution = -2,
                Intelligence = 2,
                Wisdom = 0,
                Charisma = 0
            };

            VitalStatistics total = stats + stats2;

            Assert.That(total.Strength, Is.EqualTo(9));
            Assert.That(total.Dexterity, Is.EqualTo(11));
            Assert.That(total.Constitution, Is.EqualTo(8));
            Assert.That(total.Intelligence, Is.EqualTo(12));
            Assert.That(total.Wisdom, Is.EqualTo(10));

        }

        [Test]
        public void VitalStatistics_Equals_SameStatsAreEqual()
        {
            var stats = new VitalStatistics()
            {
                Strength = 10,
                Dexterity = 9,
                Constitution = 10,
                Intelligence = 10,
                Wisdom = 8,
                Charisma = 10
            };

            var stats2 = new VitalStatistics()
            {
                Strength = 10,
                Dexterity = 9,
                Constitution = 10,
                Intelligence = 10,
                Wisdom = 8,
                Charisma = 10
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
                Strength = 8,
                Dexterity = 12,
                Constitution = 10,
                Intelligence = 1,
                Wisdom = 20,
                Charisma = 10
            };

            string repr = "Strength: 8 [-1]" + Environment.NewLine;
            repr += "Dexterity: 12 [+1]" + Environment.NewLine;
            repr += "Constitution: 10 [+0]" + Environment.NewLine;
            repr += "Intelligence: 1 [-5]" + Environment.NewLine;
            repr += "Wisdom: 20 [+5]" + Environment.NewLine;
            repr += "Charisma: 10 [+0]" + Environment.NewLine;
       
            Assert.AreEqual(repr, stats.ToString());

           
        }


    }
}