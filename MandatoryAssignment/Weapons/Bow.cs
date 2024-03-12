using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryAssignment.Weapons
{
    public class Bow: AttackItemBase
    {
        public override string Name { get { return "Bow"; } set { Name = value; } }
        public override int Hit { get { return 15; } set { Hit = value; } }
        public override int Range { get { return 20; } set { Range = value; } }
    }
}
