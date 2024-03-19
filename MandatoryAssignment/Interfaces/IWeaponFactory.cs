using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MandatoryAssignment.Interfaces.Types;

namespace MandatoryAssignment.Interfaces
{
    /*This interface is used to create a weapon of a specific type
     *     * Let the user choose between Axe, Sword, Bow and there own CreateWeapon
     *         */
    public interface IWeaponFactory 
    {
        IWeapon Create(WeaponType type);
        IWeapon Create(string name, int hit, int range);
    }
}
