namespace MandatoryAssignment.Interfaces
{

    /*
     * This interface is used to create a weapon with a name, hit and range.
     * Gaol to use interface is to make the code more flexible and to be able to switch between different types of weapons.
     */
    public interface IWeapon
    {
        string Name { get; set; }
        int Hit { get; set; }
        int Range { get; set; }
    }
}
