using MandatoryAssignment.Defenses;
using MandatoryAssignment.Interfaces;
using MandatoryAssignment.Weapons;

namespace MandatoryAssignment
{
    public class Creature
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int HitPoint { get; set; }
        //public List<AttackItem> AttackItems { get; set; } 
        //public List<DefenceItem> DefenceItems { get; set; }

        private List<AttackItemBase> AttackItems;
        private List<DefenceItemBase> DefenceItems;
        //public WorldObject WorldObject { get; set; }
        public AttackItemBase AttackItem { get; set; }
        public DefenceItemBase DefenceItem { get; set; }
        public Creature()
        {
            
        }

        public Creature(int id, string name, int hitPoint)
        {
            Id = id;
            Name = name;
            HitPoint = hitPoint;
            AttackItems = new List<AttackItemBase>();
            DefenceItems = new List<DefenceItemBase>();

        }

        public Creature(int id,string name, int hitPoint, WorldObject worldObject) : this(id, name, hitPoint)
        {
            AttackItems = new List<AttackItemBase>();
            DefenceItems = new List<DefenceItemBase>();
           
        }

        public int Hit()
        {
            // Implement logic for calculating hit points

            Random random = new Random();
            int minHitPoints = 10;
            int maxHitPoints = 20;
            int hitPoints = random.Next(minHitPoints, maxHitPoints + 1);

            return hitPoints;
        }
        public bool IsDead()
        {
            // Implement logic for checking if creature is dead
            if (HitPoint <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool IsAlive()
        {
            // Implement logic for checking if creature is alive
            if (HitPoint > 0)
            { 
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ReceiveHit(int hit)
        {
            // Implement logic for handling received hits
            HitPoint -= hit;    
        }

        public void Loot(WorldObject worldObject)
        {
            // Implement logic for looting items from the world 
            if (worldObject.Lootable == true)
            {
                //DefenceItems.Add(worldObject.DefenceItem);

                if (AttackItems.Count < 2)
                {
                    AttackItems.Add(worldObject.AttackItem);

                }
                if(DefenceItems.Count < 2)
                {
                    DefenceItems.Add(worldObject.DefenceItem);
                }
                
                if(AttackItems.Count == 2)
                {
                    //AttackItems.Clear();
                    AttackItems.Remove(AttackItems[0]);
                }
                if(DefenceItems.Count == 2)
                {
                    DefenceItems.Remove(DefenceItems[0]);
                }




            }
          

        }
    }
}
