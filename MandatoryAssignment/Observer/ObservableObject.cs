using MandatoryAssignment.Creature.Template;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace MandatoryAssignment.Observer
{
    public class ObservableObject : INotifyPropertyChanged
    {
        public CreatureBase CreatureBase { get; set; }

        public ObservableObject() { }


        public event PropertyChangedEventHandler PropertyChanged;


        protected void Notify([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void Update(object obj, PropertyChangedEventArgs args)
        {
            Console.WriteLine($"This is a named method : the changed property is {args.PropertyName}");
            Console.WriteLine($"New values is \n{obj}");
        }

       
    }
}
