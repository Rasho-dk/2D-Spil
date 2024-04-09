using MandatoryAssignment.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryAssignment.Weapons
{
    public abstract class AttackItemBase : IWeapon
    {
        public abstract string Name { get;  set; }
        public abstract int Hit { get; set; }
        public abstract int Range { get; set; }


        public override string ToString()
        {
            return $"{{{nameof(Name)}={Name}, {nameof(Hit)}={Hit.ToString()}, {nameof(Range)}={Range.ToString()}}}";
        }
    }
}
