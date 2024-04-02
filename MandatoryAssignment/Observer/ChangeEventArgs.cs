using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryAssignment.Observer
{
    public class ChangeEventArgs : EventArgs
    {
        public int HitPoint { get; set; }
    }
}
