using System;
using System.Collections.Generic;
using System.Text;

namespace CharacterLib
{
    public class Character
    {
        public string Name { get; set; }
        public VitalStatistics Stats { get; set; }
        public CharacterClass CharacterClass { get; set; }
        public int HitPoints { get; set; }
        public int MaxHitPoints { get; set; }
        //Can I put an event here and subscribe to it?


        public void TakeDamage(Damage damage)
        {
            int newHP = HitPoints - damage.Amount;
            HitPoints = (newHP > 0) ? newHP : 0;
        }

        public void Heal(int healing)
        {
            int newHP = HitPoints + healing;
            HitPoints = (newHP < MaxHitPoints) ? newHP : MaxHitPoints;
        }
    }

 
}
