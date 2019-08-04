using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissorsCore
{
    public abstract class Weapon
    {
        public string WeaponName { get; private set; }
        public List<Type> CanBeat { get; set; }
        public Weapon(string weaponName)
        {
            WeaponName = weaponName;
        }


    }
}
