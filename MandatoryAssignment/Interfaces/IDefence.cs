namespace MandatoryAssignment.Interfaces
{
    public interface IDefence
    {
         string Name { get; set; }
         int ReduceHitPoint { get; set; }
         bool FoundInChest { get; set; } // Can be found in treasure chests or bonus boxes
    }
}
