using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using CharacterLib;


namespace Tests
{

    class TestGameEffects
    {

    }
    class TestCharacterClass
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void CharacterClass_ConstructorAndProperties_ConstructorAndPropertiesWork()
        {
            int testHitPoints = 100;
            var character = new Character()
            {
                Name = "Billy Boghollow",
                HitPoints = testHitPoints,
                Stats = new VitalStatistics
                {
                    Strength = 12,
                    Dexterity = 12,
                    Constitution = 12,
                    Intelligence = 12,
                    Wisdom = 12,
                    Charisma = 12
                },
                CharacterClass = new CharacterClass()
                {
                    Name = "Fighter",
                    HitDie = 10,
                    Features = new List<Feature>() { new Feature() {
                        Name = "Second Wind",
                        Level = 1,
                        Rules = "Some text\n\n● A Markdown Bullet\n\n● Another Bullet",
                        Options = new List<Option>()
                        {
                            new Option()
                            {
                                Name = "Heal",
                                Action = "Bonus Action",
                                Effect = new GameEffect() {
                                    Target = "Self",
                                    Formula = "5",
                                    EffectType = Effect.Heal
                                }
                            }
                        }
                    } },
                    Proficiencies = new List<string>() { "Medium Armor", "Light Armor", "Simple Weapons" }
                }
            };

            Assert.Pass();
        }

    }

    class TestCharacter
    {
        [Test]
        public void Character_TakeDamage_ReducesHitPoints()
        {
            int testHitPoints = 100;
            var testDamage = new Damage(){
                Amount = 10
            };
            var character = new Character()
            {
                HitPoints = testHitPoints
            };

            character.TakeDamage(testDamage);

            Assert.AreEqual(testHitPoints - testDamage.Amount, character.HitPoints);
        }

        [Test]
        public void Character_Heal_IncreasesHitPoints()
        {
            int testHitPoints = 50;
            int testHealing = 10;
            var character = new Character()
            {
                HitPoints = testHitPoints,
                MaxHitPoints = testHitPoints + testHealing
            };
            character.Heal(testHealing);
            Assert.AreEqual(testHitPoints + testHealing, character.HitPoints);

        }

        [Test]
        public void Character_Heal_IncreasesHitPointsToMax()
        {
            int testHitPoints = 50;
            int maxHitPoints = 55;
            int testHealing = 10;
            var character = new Character()
            {
                HitPoints = testHitPoints,
                MaxHitPoints = maxHitPoints
            };
            character.Heal(testHealing);
            Assert.AreEqual(maxHitPoints, character.HitPoints);

        }

        [Test]
        public void Character_TakeDamage_DoesNotGoBelowZero()
        {
            int testHitPoints = 10;
            var testDamage = new Damage()
            {
                Amount = testHitPoints * 2
            };
            var character = new Character()
            {
                HitPoints = testHitPoints
            };

            character.TakeDamage(testDamage);

            Assert.AreEqual(0, character.HitPoints);
        }
    }
}
