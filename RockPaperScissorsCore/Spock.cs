using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissorsCore
{
    class Spock : Weapon
    {
        public Spock()
            : base("Spock")
        {
            CanBeat = new List<Type>() { typeof(Scissors), typeof(Rock) };
        }
    }
}
