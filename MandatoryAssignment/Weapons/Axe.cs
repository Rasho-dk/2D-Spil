using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryAssignment.Weapons
{
    public class Axe : AttackItemBase
    {
        public override string Name { 
            get { return "Axe"; }
            set { Name = value; }
        }
        public override int Hit 
        { 
            get { return 20;  }
            set { Hit = value; }
        
        } 
        public override int Range
        { 
            get { return 10; } 
            set { Range = value; }
        }
    }
}
