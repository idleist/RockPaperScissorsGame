using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissorsCore
{
    public class Paper : Weapon
    {
        public Paper()
            : base("Paper")
        {
            CanBeat = new List<Type>() { typeof(Rock), typeof(Spock) };
        }
    }
}
