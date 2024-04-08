using MandatoryAssignment.Creature.Template;
using MandatoryAssignment.Defenses;
using MandatoryAssignment.Gamelogger;
using MandatoryAssignment.Interfaces;
using MandatoryAssignment.Models;
using MandatoryAssignment.Observer;
using MandatoryAssignment.Weapons;
using System;

namespace MandatoryAssignment
{
    public abstract class WorldObject : IObject
    {
  

        public string Id { get; set; }
        public string Name { get; set; }
        public bool Lootable { get; set; }
        public bool Removeable { get; set; }
        //public int X { get; set; } // X-coordinate in the world
        //public int Y { get; set; } // Y-coordinate in the world

        //public Position Position { get; set; }
        public IPosition Position { get; set; }

        //public AttackItemBase AttackItem { get; set; }
        public IWeapon AttackItem { get; set; }
        //public DefenceItemBase DefenceItem { get; set; }
        public IDefence DefenceItem { get; set; }



        /// <summary>
        /// Default constructor
        /// </summary>
        protected WorldObject()
        {
            Id = Guid.NewGuid().ToString().Substring(0, 8);


        }

        /*
         Her har jeg brugt Dependency Injection for at kunne injecte en IPosition, IWeapon og IDefence ind i WorldObject klassen.
            for at kunne gøre det, har jeg lavet en interface for hver af de tre klasser, som jeg så kan injecte ind i WorldObject klassen.

        Formålet med dette er at kunne gøre WorldObject klassen mere fleksibel, så jeg kan skifte mellem forskellige typer af IPosition, IWeapon og IDefence hvis der findes.
        
         */

        /// <summary>
        /// Constructor with parameters for the WorldObject class
        /// </summary>
        /// <param name="name">Name of the world object</param> 
        /// <param name="lootable">If the object is lootable</param> 
        /// <param name="removeable">If the object is removeable</param> 
        /// <param name="position">Position of the object</param> // 
        /// <param name="attackItem">Attack item of the object</param>
        /// <param name="defenceItem">Defence item of the object</param>
        protected WorldObject(string name, bool lootable, bool removeable, IPosition position, IWeapon attackItem, IDefence defenceItem)
        {
            Id = Guid.NewGuid().ToString().Substring(0, 8);
            Name = name;
            Lootable = lootable;
            Removeable = removeable;
            Position = position;
            AttackItem = attackItem;
            DefenceItem = defenceItem;
        }

        public override string ToString()
        {
            return $"{{{nameof(Id)}={Id}, {nameof(Name)}={Name}, {nameof(Lootable)}={Lootable.ToString()}, {nameof(Removeable)}={Removeable.ToString()}, {nameof(Position)}={Position}, {nameof(AttackItem)}={AttackItem}, {nameof(DefenceItem)}={DefenceItem}}}";
        }

        

    }
}
