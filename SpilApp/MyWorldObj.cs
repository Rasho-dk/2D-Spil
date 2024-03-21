using MandatoryAssignment;
using MandatoryAssignment.Defenses;
using MandatoryAssignment.Interfaces;
using MandatoryAssignment.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpilApp
{
    public class MyWorldObj : WorldObject
    {
        public MyWorldObj()
        {
        }

        public MyWorldObj(string name, bool lootable, bool removeable, Position position, AttackItemBase attackItem, DefenceItemBase defenceItem) : base(name, lootable, removeable, position, attackItem, defenceItem)
        {
        }
    }
}
