using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissorsCore
{
    public class Rock : Weapon
    {
        public Rock()
            : base("Rock")
        {
            CanBeat = new List<Type>() { typeof(Scissors), typeof(Lizard) };
        }
    }
}
