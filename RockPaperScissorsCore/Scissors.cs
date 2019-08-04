using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissorsCore
{
    public class Scissors : Weapon
    {
        public Scissors()
            : base("Scissors")
        {
            CanBeat = new List<Type>() { typeof(Paper), typeof(Lizard) };
        }
    }
}
