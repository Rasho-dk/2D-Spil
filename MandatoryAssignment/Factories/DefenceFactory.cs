using MandatoryAssignment.Enumtype;
using MandatoryAssignment.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryAssignment.Factories
{
    public class DefenceFactory : IDefenceFactory  
    {
        /// <summary>
        ///This method creates a new defence item based on the type of defence
        /// </summary>
        /// <param name="type">The type of defence</param> 
        /// <returns> returns the defence item created based on the type</returns> 
        /// <exception cref="ArgumentException">If the type is not valid</exception> 
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
                default:
                    throw new ArgumentException($"Invalid defence type {type}");
            }
        }

        /// <summary>
        /// This method creates a new defence item based on the name, reduceHitPoint and foundInChest
        /// </summary>
        /// <param name="name">Name of the defence Item</param>
        /// <param name="reduceHitPoint">The amount of hit points the defence item can reduce</param>
        /// <param name="foundInChest">If the defence item is found in a chest</param>
        /// <returns></returns>
        public IDefence Create(string name, int reduceHitPoint, bool foundInChest)
        {
            return new Defences.CreateDefence(name, reduceHitPoint, foundInChest);      
        }
    }
}
