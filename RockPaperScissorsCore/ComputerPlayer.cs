using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissorsCore
{
    public class ComputerPlayer : IPlayer
    {

        public string Name { get; set; } = "Bob The Powerful";
        public Weapon CurrentWeapon { get; set; }

    }
}
