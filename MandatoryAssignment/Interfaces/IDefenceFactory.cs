using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MandatoryAssignment.Interfaces.Generic;
using MandatoryAssignment.Interfaces.Types;

namespace MandatoryAssignment.Interfaces
{
    public interface IDefenceFactory  : IGenericItemFactory<IDefence, DefenceType>
    {
        //IDefence Create(DefenceType type);
    }
}
