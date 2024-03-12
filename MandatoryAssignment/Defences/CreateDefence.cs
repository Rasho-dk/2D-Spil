using MandatoryAssignment.Defenses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryAssignment.Defences
{
    public class CreateDefence : DefenceItemBase
    {
        public override string Name { get; set; }
        public override int ReduceHitPoint { get ; set; }
        public override bool FoundInChest { get; set; }

        public CreateDefence()
        {
            
        }
        public CreateDefence(string name, int reduceHitPoint, bool foundInChest)
        {
            Name = name;
            ReduceHitPoint = reduceHitPoint;
            FoundInChest = foundInChest;
        }
    }
}
