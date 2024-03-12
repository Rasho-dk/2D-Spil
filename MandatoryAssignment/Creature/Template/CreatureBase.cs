using MandatoryAssignment.Defenses;
using MandatoryAssignment.Weapons;

namespace MandatoryAssignment.Creature.Template
{
    public abstract class CreatureBase
    {

        protected int Id { get; set; }
        protected string Name { get; set; }
        protected int HitPoint { get; set; }
        /// <summary>
        /// This property is used to generate random numbers using the Random class and Guid class to get a unique seed
        /// </summary>
        protected Random RandomGenerator { get; } = new Random(Guid.NewGuid().GetHashCode());

        //protected AttackItemBase AttackItem { get; set; }
        protected DefenceItemBase DefenceItem { get; set; }


        private List<AttackItemBase> AttackItems;
        private List<DefenceItemBase> DefenceItems;


        /// <summary>
        /// This constructor is default and is used to initialize the lists AttackItems and DefenceItems
        /// </summary>
        public CreatureBase()
        {
            AttackItems = new List<AttackItemBase>();
            DefenceItems = new List<DefenceItemBase>();
        }


        /// <summary>
        /// This constructor is used to initialize Id, Name and HitPoint
        /// </summary>
        /// <param name="id">Unique id for Creature</param>
        /// <param name="name">Name of Creature</param>
        /// <param name="hitPoint">How many points does the Creature have</param>
        protected CreatureBase(int id, string name, int hitPoint) : this()
        {
            Id = id;
            Name = name;
            HitPoint = hitPoint;
        }

        /// <summary>
        /// This method is used to fight against the opponent
        /// </summary>
        /// <param name="opponent">The opponent that the Creature is fighting against</param> 
        public void Fight(CreatureBase opponent)
        {
            Console.WriteLine($"{Name} is attacking {opponent.Name}!");
            Attack(opponent);
            opponent.Defend(this);
            //ReceiveHit(opponent.Hit());
            if (!opponent.IsDead())
            {
                Console.WriteLine($"{opponent.Name} is retaliating against {Name}!");
                opponent.Attack(this);
            }
            // Check if the creature is dead after the turn
            if (IsDead())
            {
                Console.WriteLine($"{Name} is dead!");
            }
            if (opponent.IsDead())
            {
                Console.WriteLine($"{opponent.Name} is dead!");
            }
            else
            {
                Console.WriteLine($"{Name} has {HitPoint} hit points left!");
                Console.WriteLine($"{opponent.Name} has {opponent.HitPoint} hit points left!");
            }
        }

        #region Abstract methods to be implemented by subclasses
        // Method for attacking opponent
        protected abstract void Attack(CreatureBase opponent);

        // Method for defending against opponent
        protected abstract void Defend(CreatureBase opponent);

        #endregion

        /// <summary>
        /// This method is used to calculate the hit points of the Creature
        /// </summary>
        /// <returns>Returns the hit points of the Creature</returns> 
        public int Hit()
        {
            int minHitPoints = 10;
            int maxHitPoints = 20;
            int hitPoints = RandomGenerator.Next(minHitPoints, maxHitPoints + 1);

            return hitPoints;
        }
        /// <summary>
        /// This method is used to check if the Creature is dead
        /// </summary>
        /// <returns>True/False</returns>
        public bool IsDead()
        {
            return HitPoint <= 0;
        }
        /// <summary>
        /// This method is used to check if the Creature is alive
        /// </summary>
        /// <returns>True/False</returns>
        public bool IsAlive()
        {
            return HitPoint > 0;
        }
        /// <summary>
        /// This method is used to receive hit points from the opponent
        /// </summary>
        /// <param name="damage">The damage that the Creature receives</param> 
        public void ReceiveHit(int damage)
        {
             HitPoint -= damage;
        }

        /// <summary>
        /// This method is used to add AttackItem and DefenceItem to Creature if the Lootable is true
        /// If there are more than 2 AttackItems or DefenceItems then it removes the first item in the list and adds the new item
        /// </summary>
        /// <param name="worldObject">These objects that exist in the game world</param>

        public virtual void Loot(WorldObject worldObject)
        {
            if (worldObject.Lootable)
            {
                if (AttackItems.Count < 2)
                {
                    AttackItems.Add(worldObject.AttackItem);
                }
                if (DefenceItems.Count < 2)
                {
                    DefenceItems.Add(worldObject.DefenceItem);
                }
                if (AttackItems.Count == 2)
                {
                    AttackItems.RemoveAt(0);
                }
                if (DefenceItems.Count == 2)
                {
                    DefenceItems.RemoveAt(0);
                }
            }
        }
        /// <summary>
        /// This method is used to get the AttackItems
        /// </summary>
        /// <returns>List of AttackItems</returns>
        public IEnumerable<DefenceItemBase> GetDefenceItems()
        {
            return DefenceItems;

        }
        /// <summary>
        /// This print the Creature's Id, Name, HitPoint, AttackItems and DefenceItems
        /// </summary>
        /// <returns>string representation of the Creature</returns>
        public override string ToString()
        {
            string attackItemsString = string.Join(", ", AttackItems);
            string defenceItemsString = string.Join(", ", DefenceItems);

            return $"Id: {Id}, Name: {Name}, HitPoint: {HitPoint}, AttackItems: {attackItemsString}, DefenceItems: {defenceItemsString}";
        }
    }
}
