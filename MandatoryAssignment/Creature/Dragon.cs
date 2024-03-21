using MandatoryAssignment.Creature.Template;
using MandatoryAssignment.Defenses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryAssignment.Creature
{
    public class Dragon : CreatureBase
    {
        public int Damage { get; set; }
        public Dragon( string name, int hitPoint) : base(name, hitPoint)
        {
        }

        protected override void Attack(CreatureBase creatureBase)
        {   
            ReceiveHit(creatureBase.Hit());

            //TODO: Add a method to handle the case when the creature dont have any attack items
        }

        protected override void Defend(CreatureBase creatureBase)
        {
            ReceiveReduceHitPoint(ReduceHitPoint());

            //TODO: Add a method to handle the case when the creature dont have any defence items
        }
    }
}
