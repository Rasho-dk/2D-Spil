using MandatoryAssignment.Interfaces;
using MandatoryAssignment.Interfaces.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryAssignment.Factories
{
    public class WeaponFactory : IWeaponFactory
    {
        public IWeapon Create(WeaponType type)
        {
            switch (type)
            {
                case WeaponType.Axe:
                    return new Weapons.Axe();
                case WeaponType.Sword:
                    return new Weapons.Sword();
                case WeaponType.Bow:
                    return new Weapons.Bow();
                case WeaponType.CreateWeapon:
                    // Allow user to create a new weapon
                    Console.WriteLine("Enter the name of the new weapon:");
                    string weaponName = Console.ReadLine();
                    Console.WriteLine("Enter the hit of the new weapon:");
                    int hit = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the damage of the new weapon:");
                    int weaponRange = int.Parse(Console.ReadLine());
                    return new Weapons.CreateWeapon(weaponName, hit, weaponRange);
                default:
                    throw new ArgumentException($"Invalid weapon type {type}");
            }
        }
    }
}
