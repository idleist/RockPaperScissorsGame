using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissorsCore
{
    public class Lizard : Weapon
    {
        public Lizard()
            : base("Lizard")
        {
            CanBeat = new List<Type>() { typeof(Paper), typeof(Spock) };
        }
    }
}
