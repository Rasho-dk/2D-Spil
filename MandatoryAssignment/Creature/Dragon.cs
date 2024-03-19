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
        public Dragon(int id, string name, int hitPoint) : base(id, name, hitPoint)
        {
        }

        protected override void Attack(CreatureBase creatureBase)
        {
           
            ReceiveHit(creatureBase.Hit());
        }

        protected override void Defend(CreatureBase creatureBase)
        {
            creatureBase.GetDefenceItems()
                .OfType<DefenceItemBase>()
                .ToList()
                .ForEach(item => ReceiveHit(item.ReduceHitPoint));

            //foreach (var item in creatureBase.GetDefenceItems())
            //{

            //    if (item is DefenceItemBase)
            //    {
            //        ReceiveHit(item.ReduceHitPoint);

            //    }

            //}
        }
    }
}
