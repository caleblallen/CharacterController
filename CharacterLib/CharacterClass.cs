using System;
using System.Collections.Generic;
using System.Text;

namespace CharacterLib
{
    public class CharacterClass
    {
        public string Name { get; set; }
        public int HitDie { get; set; }
        public List<Feature> Features { get; set; }
        public List<string> Proficiencies { get; set; }
    }
}
