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
        /// <summary>
        /// This method is used to create a weapon of a specific type
        /// </summary>
        /// <param name="type">The type of weapon to create</param>
        /// <returns>returns the weapon created based on the type</returns>//
        /// <exception cref="ArgumentException">throw exception if the type is not valid</exception>  
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
                default:
                    throw new ArgumentException($"Invalid weapon type {type}");
            }
        }
        /// <summary>
        /// This method is used to create a weapon based on the name, hit and range
        /// </summary>
        /// <param name="name">name of the weapon</param>
        /// <param name="hit">hit points of the weapon</param>
        /// <param name="range">range of the weapon</param>
        /// <returns>returns the weapon created based on the name, hit and range</returns> 
        public IWeapon Create(string name, int hit, int range)
        {
            return new Weapons.CreateWeapon(name, hit, range);
      
        }
    }
}
