using MandatoryAssignment.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryAssignment.Weapons
{
    public class CreateWeapon : AttackItemBase
    {
        public override string Name { get; set; }
        public override int Hit { get; set; }
        public override int Range { get; set; }

        public CreateWeapon(string name, int hit, int range)
        {
            Name = name;
            Hit = hit;
            Range = range;
        }
        public CreateWeapon()
        {
            
        }
    }
}
