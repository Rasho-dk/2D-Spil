using MandatoryAssignment.Creature.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryAssignment.Creature
{
    public class CreatureBehavior
    {
        private CreatureBase creatureBase;
        public CreatureBehavior(CreatureBase creatureBase)
        {
            this.creatureBase = creatureBase;
        }
        public void Attack(CreatureBase creatureBase)
        {
            creatureBase.ReceiveHit(creatureBase.Hit());
        }

        public void Defend(CreatureBase creatureBase)
        {
            creatureBase.ReceiveReduceHitPoint(creatureBase.ReduceHitPoint());
        }

        public string Fight(CreatureBase creatureBase)
        {
            Attack(creatureBase);
            Defend(creatureBase);
            return creatureBase.ToString();
        }
    }
}
