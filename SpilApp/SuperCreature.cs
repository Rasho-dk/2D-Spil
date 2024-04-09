using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpilApp
{
    /// <summary>
    /// SuperCreature class 
    /// This class is used to create a SuperCreature object where the hitpoint is getting higher
    /// </summary>
    public class SuperCreature
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int HitPoint { get; set; }
        public int Power { get; set; }

        public SuperCreature(string id ,string name, int hitPoint, int power)
        {
            Id = id;
            Name = name;
            HitPoint = hitPoint;
            Power = power;
        }

        public SuperCreature(string id, string name, int hitPoint)
        {
            Id = id;
            Name = name;
            HitPoint = hitPoint;
        }

        public override string ToString()
        {
            return $"{{{nameof(Id)}={Id}, {nameof(Name)}={Name}, {nameof(HitPoint)}={HitPoint.ToString()}, {nameof(Power)}={Power.ToString()}}}";
        }
    }
}
