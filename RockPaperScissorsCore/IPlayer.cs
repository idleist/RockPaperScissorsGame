using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissorsCore
{
    public interface IPlayer
    {
        string Name { get; set; }
        Weapon CurrentWeapon { get; set; }
    }
}
