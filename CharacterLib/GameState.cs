using System;
using System.Collections.Generic;
using System.Text;

namespace CharacterLib
{
    public enum Effect
    {
        Damage,
        Heal
    }

    public class GameState
    {
        //public delegate void FireGameEffect(Character pc, GameEffect effect);

        //public FireGameEffect Fire;

        public Character PlayerCharacter { get; set; }

        public GameState() { }
        public GameState(Character pc)
        {
            PlayerCharacter = pc;
        }

        public void ApplyGameEffect(GameEffect ge)
        {
            if (ge.EffectType == Effect.Heal)
                HealEffect(ge);
        }

        private void HealEffect(GameEffect ge)
        {

        }
    }
}
