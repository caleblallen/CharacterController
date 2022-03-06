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
        public event EventHandler<CharacterEventArgs> Triggers;

        public void TakeDamage(Damage damage)
        {
            int newHP = HitPoints - damage.Amount;

            if (newHP > 0)
                HitPoints = newHP;
            else
            {
                HandleCharacterGoesUnconcious(damage);

            }

        }
        private void HandleCharacterGoesUnconcious(Damage damage)
        {
            bool characterIsInstantlyKilled = Math.Abs(HitPoints - damage.Amount) >= MaxHitPoints;

            HitPoints = 0;

            EmitUnconciousOrDead(damage, characterIsInstantlyKilled);
        }

        private void EmitUnconciousOrDead(Damage damage, bool characterIsInstantlyKilled)
        {
            string currentState = characterIsInstantlyKilled ? "instantly killed" : "knocked unconcious";

            Triggers?.Invoke(this, new CharacterEventArgs()
            {
                Message = $"{Name} took {damage.Amount} damage and was {currentState}."
            });
        }

        public void Heal(int healing)
        {
            int newHP = HitPoints + healing;
            HitPoints = (newHP < MaxHitPoints) ? newHP : MaxHitPoints;
        }
    }

 
}
