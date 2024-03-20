using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MandatoryAssignment.Enumtype;

namespace MandatoryAssignment.Interfaces
{
    public interface IDefenceFactory  
    {
        IDefence Create(DefenceType type);
        IDefence Create(string name, int reduceHitPoint, bool foundInChest);
    }
}
