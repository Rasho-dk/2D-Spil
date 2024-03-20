namespace MandatoryAssignment.Liskov
{
    public class NotNegativNumber
    {
        private int _number;
        public int Number
        {
            get => _number;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Number must be a positive number");
                }
                _number = value;
            }
        }
    }
}
