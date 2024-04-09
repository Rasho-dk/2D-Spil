using MandatoryAssignment.Creature.Template;
using MandatoryAssignment.Defenses;
using MandatoryAssignment.Liskov;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryAssignment.Creature
{
    public class CreateCreature : CreatureBase
    {
        /// <summary>
        /// Ths is the constructor for the CreateCreature class that inherits from the CreatureBase class and takes in the parameters id, name and hitPoint 
        /// </summary>
        /// <param name="id">The id of the creature</param>
        /// <param name="name">The name of the creature</param>
        /// <param name="hitPoint">The hitpoint of the creature</param>
        public CreateCreature(string name, int hitPoint) : base( name, hitPoint)
        {
        }
        /// <summary>
        /// This method is used to attack another creature
        /// </summary>
        /// <param name="creatureBase">The creature to attack </param>
        protected override void Attack(CreatureBase creatureBase)
        {
            ReceiveHit(creatureBase.Hit());

            //TODO: Add a method to handle the case when the creature dont have any attack items

        }
        /// <summary>
        /// This method is used to defend against an attack
        /// </summary>
        /// <param name="creatureBase">The creature to defend against another creature</param> 
        protected override void Defend(CreatureBase creatureBase)
        {

            ReceiveReduceHitPoint(ReduceHitPoint());

            //TODO: Add a method to handle the case when the creature dont have any defence items
        }
    }
}
