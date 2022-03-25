using System;
using System.Collections.Generic;
using System.Text;
using CharacterLib;

namespace CharacterController
{
    class Program
    {
        static void Main(string[] args)
        {
            bool done = false;

            while (!done)
            {
                Console.Clear();
                Console.Write("Enter comm >");
                string cmd = Console.ReadLine();

                var billy = getTestCharacter();

                Console.Write($"You entered '{billy.Stats}'");

                done = true;
            }

        }

        private static Character getTestCharacter()
        {
            return new Character()
            {
                Name = "Billy Boghollow",
                HitPoints = 100,
                Stats = new VitalStatistics
                {
                    Strength = new Stat { Score = 12 },
                    Dexterity = new Stat { Score = 12 },
                    Constitution = new Stat { Score = 12 },
                    Intelligence = new Stat { Score = 12 },
                    Wisdom = new Stat { Score = 12 },
                    Charisma = new Stat { Score = 12 }
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
        }
    }
}
