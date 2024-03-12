using MandatoryAssignment.Interfaces;
using MandatoryAssignment.Interfaces.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryAssignment.Factories
{
    public class DefenceFactory : IDefenceFactory    //: IGenericItem<IDefence, DefenceType> //: IDefenceFactory
    {
        public IDefence Create(DefenceType type)
        {
            switch (type)
            {
                case DefenceType.Shield:
                    return new Defences.Shield();
                case DefenceType.Armor:
                    return new Defences.Armor();
                case DefenceType.Helmet:
                    return new Defences.Helmet();
                case DefenceType.CreateDefence:
                    //Allow user to create their own defence
                    Console.WriteLine("Enter the name of the new defence:");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter the hit of the new defence:");
                    int reduceHitPoint = int.Parse(Console.ReadLine());
                    Console.WriteLine("Is the new defence found in a chest? (true/false)");
                    bool foundInChest = bool.Parse(Console.ReadLine());
                    return new Defences.CreateDefence(name, reduceHitPoint, foundInChest);
                default:
                    throw new ArgumentException($"Invalid defence type {type}");
            }
        }

       
    }
}
