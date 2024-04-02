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

        /// <summary>
        /// This method is used to get the position of the object in the game
        /// </summary>
        /// <returns>Return the position of the object in the game</returns> 
        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }
        /// <summary>
        /// This method is used to compare the position of the object in the game
        /// </summary>
        /// <param name="obj">The object</param>
        /// <returns>return true or false</returns>
        public override bool Equals(object? obj)
        {
            return obj is Position position &&
                   X == position.X &&
                   Y == position.Y;
        }


        //TODO: Add a method to move the object in the game 
        //TODO: Add a method to get the position of the object in the game

        public static Position operator + (Position a, Position b)
        {
            return new Position(a.X + b.X, a.Y + b.Y);
        }

        public static Position operator - (Position a, Position b)
        {
            return new Position(a.X - b.X, a.Y - b.Y);
        }

        public static bool operator == (Position a, Position b)
        {
            return a.Equals(b);
        }

        public static bool operator != (Position a, Position b)
        {
            return !a.Equals(b);
        }

        public override string ToString()
        {
            return $"{{{nameof(X)}={X.ToString()}, {nameof(Y)}={Y.ToString()}}}";
        }

        public void Move(int x, int y)
        {
            X += x;
            Y += y;
        }



    }
}
