using MandatoryAssignment.Defenses;
using MandatoryAssignment.Interfaces;
using MandatoryAssignment.Weapons;

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

        public Position Position { get; set; }

        public AttackItemBase AttackItem { get; set; }
        public DefenceItemBase DefenceItem { get; set; }


        /// <summary>
        /// Default constructor
        /// </summary>
        protected WorldObject()
        {
            Id = Guid.NewGuid().ToString().Substring(0, 8);

        }

        /// <summary>
        /// Constructor with parameters for the WorldObject class
        /// </summary>
        /// <param name="name">Name of the world object</param> 
        /// <param name="lootable">If the object is lootable</param> 
        /// <param name="removeable">If the object is removeable</param> 
        /// <param name="position">Position of the object</param> // 
        /// <param name="attackItem">Attack item of the object</param>
        /// <param name="defenceItem">Defence item of the object</param>
        protected WorldObject(string name, bool lootable, bool removeable, Position position, AttackItemBase attackItem, DefenceItemBase defenceItem)
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
