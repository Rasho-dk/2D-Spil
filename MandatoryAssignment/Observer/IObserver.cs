using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryAssignment.Observer
{
    public interface IObserver
    {
        void Update(ISubject subject);

    }
}
