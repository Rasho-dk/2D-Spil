using MandatoryAssignment.Defenses;
using MandatoryAssignment.Weapons;

namespace MandatoryAssignment
{
    public class WorldObject
    {
        public string Name { get; set; }
        public bool Lootable { get; set; }
        public bool Removeable { get; set; }
        public int X { get; set; } // X-coordinate in the world
        public int Y { get; set; } // Y-coordinate in the world

        public AttackItemBase AttackItem { get; set; }
        public DefenceItemBase DefenceItem { get; set; }

        public WorldObject()
        {

        }

        public WorldObject(string name, bool lootable, bool removeable, int x,
            int y, AttackItemBase attackItem, DefenceItemBase defenceItem)
        {
            Name = name;
            Lootable = lootable;
            Removeable = removeable;
            X = x;
            Y = y;
            AttackItem = attackItem;
            DefenceItem = defenceItem;
        }

       

    }
}
