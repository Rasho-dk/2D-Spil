using MandatoryAssignment.Defenses;
using MandatoryAssignment.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryAssignment.Defences
{
    public class Armor : DefenceItemBase
    {
        public override string Name { get { return "Armor"; } set { Name = value; } }

        public override int ReduceHitPoint { get { return 20; } set { ReduceHitPoint = value; } }

        public override bool FoundInChest { get { return true; } set { FoundInChest = value; } }
    }
}
