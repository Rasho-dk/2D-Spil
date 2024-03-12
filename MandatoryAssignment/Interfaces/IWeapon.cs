namespace MandatoryAssignment.Interfaces
{

    /*
     * This interface is used to create a weapon with a name, hit and range.
     */
    public interface IWeapon
    {
        string Name { get; set; }
        int Hit { get; set; }
        int Range { get; set; }
    }
}
