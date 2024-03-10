namespace MandatoryAssignment.Weapons
{
    public class Sword : AttackItemBase
    {
        public override string Name
        { 
            get { return "Sword";}
                
        }

        public override int Hit { get { return 10; } }
        public override int Range { get { return 10; } }


    }
}
