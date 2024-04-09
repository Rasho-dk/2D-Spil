using MandatoryAssignment.Interfaces;

namespace MandatoryAssignment.Defenses
{
    public abstract class DefenceItemBase : IDefence
    {
        public abstract string Name { get; set; }

        public abstract int ReduceHitPoint { get; set; }

        public abstract bool FoundInChest { get; set; }

        public override string ToString()
        {
            return $"{{{nameof(Name)}={Name}, {nameof(ReduceHitPoint)}={ReduceHitPoint.ToString()}, {nameof(FoundInChest)}={FoundInChest.ToString()}}}";
        }
    }
}
