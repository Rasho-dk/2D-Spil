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
        static abstract IDefence Create(DefenceType type);
        static abstract IDefence Create(string name, int reduceHitPoint, bool foundInChest);
    }
}
