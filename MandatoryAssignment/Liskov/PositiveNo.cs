namespace MandatoryAssignment.Liskov
{
    /*
     * Her bliver der burgt listov substitution princippet som er en del  af SOLID princip, da jeg har lavet en ny klasse PositiveNo. 
     * Formålet med denne klasse er at sikre at et tal er positivt, og hvis det ikke er det, så vil der blive kastet en exception.
     * Den klassr kan bruges i stedet for en int, da den har samme funktionalitet. 
     */
    public class PositiveNo
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
