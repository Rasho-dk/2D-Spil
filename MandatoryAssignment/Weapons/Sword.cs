namespace MandatoryAssignment.Weapons
{
    public class Sword : AttackItemBase
    {
        public override string Name
        {
            get { return "Sword"; }
            set { Name = value; }

        }

        public override int Hit { get { return 10; } set { Hit = value; } }
        public override int Range { get { return 10; } set { Range = value; } }


    }
}
