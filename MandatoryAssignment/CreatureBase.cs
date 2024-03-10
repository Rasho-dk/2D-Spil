using MandatoryAssignment.Defenses;
using MandatoryAssignment.Interfaces;
using MandatoryAssignment.Weapons;

namespace MandatoryAssignment
{
    public abstract class CreatureBase
    {
        protected int Id { get; set; }
        protected string Name { get; set; }
        protected int HitPoint { get; set; }
        private List<AttackItemBase> AttackItems;
        private List<DefenceItemBase> DefenceItems;
        protected AttackItemBase AttackItem { get; set; }
        protected DefenceItemBase DefenceItem { get; set; }
        

        /// <summary>
        /// Den her constructor er default og bliver brugt til at initialisere listerne AttackItems og DefenceItems
        /// </summary>
        public CreatureBase()
        {
            AttackItems = new List<AttackItemBase>();
            DefenceItems = new List<DefenceItemBase>();
        }
        /// <summary>
        /// Den her constructor bliver brugt til at initialisere Id, Name og HitPoint
        /// </summary>
        /// <param name="id">Unik id til Creature</param>
        /// <param name="name">Navn på Creature</param>
        /// <param name="hitPoint">Hvor man point har den Creature</param>
        protected CreatureBase(int id, string name, int hitPoint) : this()
        {
            Id = id;
            Name = name;
            HitPoint = hitPoint;
        }

        //TODO ..
        private static Random _rn = new Random(Guid.NewGuid().GetHashCode());

        public int Hit()
        {
            //Random random = new Random();
            int minHitPoints = 10;
            int maxHitPoints = 20;
            int hitPoints = _rn.Next(minHitPoints, maxHitPoints + 1);

            return hitPoints;
        }

        public bool IsDead()
        {
            return HitPoint <= 0;
        }

        public bool IsAlive()
        {
            return HitPoint > 0;
        }

        public void ReceiveHit(int hit)
        {
            HitPoint -= hit;
        }

        /// <summary>
        /// Den her metode bliver brugt til at tilføje AttackItem og DefenceItem til Creature hvis de er Lootable 
        /// Hvis der er mere end 2 AttackItems eller DefenceItems så fjerner den det første item i listen og tilføjer det nye item
        /// </summary>
        /// <param name="worldObject">Disse Objekter der findes i spil verden</param>

        public void Loot(WorldObject worldObject)
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
    }
}
