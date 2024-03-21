using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryAssignment.Models
{
    /*
     Ide of this class this for fetching the position of the player and the enemy in the game
     In feature we can use this class for the position of the object in the game and move the object in the game
     */
    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Position()
        {
            

        }
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        //TODO: Add a method to move the object in the game 
        //TODO: Add a method to get the position of the object in the game
    }
}
