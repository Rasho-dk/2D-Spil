using MandatoryAssignment.Defenses;
using MandatoryAssignment.Gamelogger;
using MandatoryAssignment.Interfaces;
using MandatoryAssignment.Liskov;
using MandatoryAssignment.Observer;
using MandatoryAssignment.Weapons;
using System.Diagnostics;

namespace MandatoryAssignment.Creature.Template
{
    /// <summary>
    /// This class is abstract and is used as a template for the Creature class.
    /// Benefit of using abstract class is that it can have abstract methods and properties that can be implemented by the subclasses
    /// </summary>

    public abstract class CreatureBase : ISubject
    {
     
        //event
        public event EventHandler<ChangeEventArgs> HitPointChanged = null!;

        public string Id { get; private set; }
        public string Name { get; set; }

        //public int HitPoint { get; set; }
        private int hitPoint;

        public int HitPoint
        {
            get { return hitPoint; }
            set
            {
                hitPoint = value;
                if (IsDead())
                {
                    //Notify observers
                    OnChange(new ChangeEventArgs() { HitPoint = hitPoint });
                }

            }
        }

        #region Delete me
        /// <summary>
        /// This property is used to generate random numbers using the Random class and Guid class to get a unique seed
        /// </summary>
        //protected Random RandomGenerator { get; } = new Random(Guid.NewGuid().GetHashCode());

        //protected AttackItemBase AttackItem { get; set; }
        //protected DefenceItemBase DefenceItem { get; set; }
        //protected AttackItemBase AttackItemBase { get; set; }
        #endregion End Delete

        private List<AttackItemBase> AttackItems;
        private List<DefenceItemBase> DefenceItems;




        /// <summary>
        /// This constructor is default and is used to initialize the lists AttackItems and DefenceItems
        /// </summary>
        public CreatureBase()
        {
            //DefenceItem = new CreateDefence();
            Id = Guid.NewGuid().ToString().Substring(0, 8);
            AttackItems = new List<AttackItemBase>();
            DefenceItems = new List<DefenceItemBase>();
        }


        /// <summary>
        /// This constructor is used to initialize Id, Name and HitPoint
        /// </summary>
        /// <param name="id">Unique id for Creature</param>
        /// <param name="name">Name of Creature</param>
        /// <param name="hitPoint">How many points does the Creature have</param>
        protected CreatureBase(string name, int hitPoint) : this()
        {
            Id = Guid.NewGuid().ToString().Substring(0, 8); ;
            Name = name;
            HitPoint = hitPoint;
        }

        /// <summary>
        /// This method is used to fight against the opponent
        /// </summary>
        /// <param name="opponent">The opponent that the Creature is fighting against</param> 
        public string Fight(CreatureBase opponent)
        {
            TraceSourceLibrary.LogEvent(TraceEventType.Information, 1, $"{Name} is fighting against {opponent.Name}!");

            opponent.Defend(this);

            Attack(opponent);

            if (!opponent.IsDead())
            {
                TraceSourceLibrary.LogInformation(1, $"{opponent.Name} is retaliating against {Name}!");
                opponent.Attack(this);
            }

            // Check if the creature is dead after the turn
            if (IsDead())
            {
                TraceSourceLibrary.LogInformation(1, $"{Name} is dead!");
                TraceSourceLibrary.LogInformation(1, $"{opponent.Name} is the winner!");
                return $"{opponent.Id}";

            }

            if (HitPoint < 20)
            {
                TraceSourceLibrary.LogEvent(TraceEventType.Warning, 1, $"{Name} should be careful, it has less than {HitPoint} hit points left!");
            }
            //Console.WriteLine($"{Name} has {HitPoint} hit points left!");
            if (opponent.HitPoint < 20)
            {
                TraceSourceLibrary.LogEvent(TraceEventType.Warning, 1, $"{opponent.Name} should be careful, it has less than {opponent.HitPoint} hit points left!");
            }
            if (opponent.IsDead())
            {
                TraceSourceLibrary.LogInformation(1, $"{opponent.Name} is dead!");
                TraceSourceLibrary.LogInformation(1, $"{Name} is the winner!");
                return $"{Id}";
            }

            return "No winner yet!";
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
        public PositiveNo Hit()
        {

            int dmg = 0;
            AttackItems.ForEach(item => dmg += item.Hit);
            return new PositiveNo() { Number = dmg };

        }
        /// <summary>
        /// This method is used to reduce the hit points of the Creature by defining against the opponent
        /// </summary>
        /// <returns></returns>
        public PositiveNo ReduceHitPoint()
        {
            int dmg = 0;
            DefenceItems.ForEach(item => dmg += item.ReduceHitPoint);
            return new PositiveNo() { Number = dmg };
        }
        /// <summary>
        /// This method is used to receive hit points from the opponent from the ReduceHitPoint method
        /// </summary>
        /// <param name="damage"></param>
        public void ReceiveReduceHitPoint(PositiveNo damage)
        {
            HitPoint -= damage.Number;
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
        public void ReceiveHit(PositiveNo damage)
        {
            HitPoint -= damage.Number;
        }


        /// <summary>
        /// This method is used to add AttackItem and DefenceItem to Creature if the Lootable is true
        /// If there are more than 2 AttackItems or DefenceItems then it removes the first item in the list and adds the new item
        /// </summary>
        /// <param name="worldObject">These objects that exist in the game world</param>

        public virtual void Loot(WorldObject worldObject)
        {
            //Ide to have a list is for future use, if we want to add more than 2 items to the creature

            if (worldObject.Lootable)
            {
                if (AttackItems.Count < 2)
                {
                    AttackItems.Add((AttackItemBase)worldObject.AttackItem);
                }
                if (DefenceItems.Count < 2)
                {
                    DefenceItems.Add((DefenceItemBase)worldObject.DefenceItem);
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


        /// <summary>
        /// This method is used to attach an observer to the Creature
        /// </summary>
        /// <param name="observer">observer to be attached</param>
        public void Attach(IObserver observer) => HitPointChanged += observer.Update;


        /// <summary>
        /// This method is used to detach an observer from the Creature
        /// </summary>
        /// <param name="observer"></param>
        public void Detach(IObserver observer) => HitPointChanged -= observer.Update;

        /// <summary>
        /// This method is used to notify the observers and update the hit points
        /// </summary>
        /// <param name="e">event arguments</param> 
        public virtual void OnChange(ChangeEventArgs e)
        {
            HitPointChanged?.Invoke(this, e);
        }
    }
}
