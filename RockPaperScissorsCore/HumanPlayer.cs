using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissorsCore
{
    public class HumanPlayer : IPlayer
    {
        public string Name { get; set; }
        public Weapon CurrentWeapon { get; set; }
        public HumanPlayer(string name)
        {
            Name = name;
        }
    }
}
