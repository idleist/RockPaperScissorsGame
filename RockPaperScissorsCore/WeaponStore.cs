using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissorsCore
{

    public class WeaponStore
    {
        public List<Weapon> Weapons { get; set; } = new List<Weapon>();

        public WeaponStore(params Weapon[] args)
        {
            foreach (var weapon in args)
            {
                Weapons.Add(weapon);
            }
        }

        public void AddWeaponToStore(Weapon weapon)
        {
            Weapons.Add(weapon);
        }
    }
}
