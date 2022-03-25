using System;
using System.Collections.Generic;
using System.Text;

namespace CharacterLib
{
    public class Feature
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public string Rules { get; set; }
        public List<Option> Options { get; set; }
    }
}
