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
        public IDefence CreateDefence(DefenceType type)
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
    }
}
