using MandatoryAssignment.Creature;
using MandatoryAssignment.Creature.Template;
using MandatoryAssignment.Defences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpilApp
{
    public class Creature : CreateCreature
    {
        public Creature(string name, int hitPoint) : base(name, hitPoint)
        {
        }
    }
}
