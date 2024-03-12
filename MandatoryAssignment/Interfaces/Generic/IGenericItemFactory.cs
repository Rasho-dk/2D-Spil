using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryAssignment.Interfaces.Generic
{
    public interface IGenericItemFactory<T, U>
    {
        T Create(U type);
    }
}
