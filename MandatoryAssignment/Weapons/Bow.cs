using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryAssignment.Weapons
{
    public class Bow: AttackItemBase
    {
        public override string Name { get { return "Bow"; } }
        public override int Hit { get { return 15; } }
        public override int Range { get { return 20; } }
    }
}
