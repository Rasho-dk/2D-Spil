using MandatoryAssignment.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryAssignment.Factories
{
    public class WeaponFactory : IWeaponFactory
    {
        public IWeapon CreateWeapon(WeaponType type)
        {
            switch(type)
            {
                case WeaponType.Axe:
                    return new Weapons.Axe();
                case WeaponType.Sword:
                    return new Weapons.Sword();
                case WeaponType.Bow:
                    return new Weapons.Bow();
                default:
                    throw new ArgumentException($"Invalid weapon type {type}");
            }
        }
    }
}
