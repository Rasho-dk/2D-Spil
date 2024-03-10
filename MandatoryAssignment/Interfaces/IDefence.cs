namespace MandatoryAssignment.Interfaces
{
    public interface IDefence
    {
         string Name { get; }
         int ReduceHitPoint { get; }
         bool FoundInChest { get; } // Can be found in treasure chests or bonus boxes
    }
}
