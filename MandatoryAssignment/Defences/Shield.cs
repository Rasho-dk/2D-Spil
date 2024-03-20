using MandatoryAssignment.Defenses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryAssignment.Defences
{
    public class Shield : DefenceItemBase
    {
        public override string Name { get { return "Shield"; } set { Name = value; } }
        public override int ReduceHitPoint { get { return 5; } set { ReduceHitPoint = value; } }

        public override bool FoundInChest { get { return true;  } set { FoundInChest = value; } }

    }
}
