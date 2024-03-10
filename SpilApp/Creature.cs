using MandatoryAssignment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpilApp
{
    public class Creature : CreatureBase
    {
        public Creature()
        {
        }

        public Creature(int id, string name, int hitPoint) : base(id, name, hitPoint)
        {
        }

      
        public override string ToString()
        {
            return $"{{{nameof(Id)}={Id.ToString()}, {nameof(Name)}={Name}, {nameof(HitPoint)}={HitPoint.ToString()}}}";
               }
        }
    }

