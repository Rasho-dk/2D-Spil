using MandatoryAssignment.Defenses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryAssignment.Defences
{
    public class Helmet : DefenceItemBase
    {
        public override string Name { get { return "Helmet"; } }

        public override int ReduceHitPoint { get { return 10; } }

        public override bool FoundInChest { get { return true; } }
    }
}
