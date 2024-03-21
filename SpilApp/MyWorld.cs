using MandatoryAssignment;
using MandatoryAssignment.Creature.Template;
using MandatoryAssignment.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpilApp
{
    public class MyWorld : World
    {
        public MyWorld()
        {
        }

        /// <summary>
        /// This is the constructor for the World class that takes in the position of the world, the world name, a list of creatures and a list of world objects
        /// </summary>
        /// <param name="position">Position of the world</param> 
        /// <param name="worldName">Name of the world</param>
        public MyWorld(Position position, string worldName) : base(position, worldName)
        {
        }

       
   


    }
}
