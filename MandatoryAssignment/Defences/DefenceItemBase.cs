using MandatoryAssignment.Interfaces;

namespace MandatoryAssignment.Defenses
{
    public abstract class DefenceItemBase : IDefence
    {
        public abstract string Name { get; }

        public abstract int ReduceHitPoint { get;}

        public abstract bool FoundInChest { get; }

        public override string ToString()
        {
            return $"{{{nameof(Name)}={Name}, {nameof(ReduceHitPoint)}={ReduceHitPoint.ToString()}, {nameof(FoundInChest)}={FoundInChest.ToString()}}}";
        }
    }
}
