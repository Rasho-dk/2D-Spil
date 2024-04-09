//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace MandatoryAssignment.Models
//{
//    /*
//     Ide of this class this for fetching the position of the player and the enemy in the game
//     In feature we can use this class for the position of the object in the game and move the object in the game
//     */
//    public class Akiv
//    {
//        public int X { get; set; }
//        public int Y { get; set; }

//        public Akiv()
//        {
            

//        }
//        public Akiv(int x, int y)
//        {
//            X = x;
//            Y = y;
//        }

//        /// <summary>
//        /// This method is used to get the position of the object in the game
//        /// </summary>
//        /// <returns>Return the position of the object in the game</returns> 
//        public override int GetHashCode()
//        {
//            return HashCode.Combine(X, Y);
//        }
//        /// <summary>
//        /// This method is used to compare the position of the object in the game
//        /// </summary>
//        /// <param name="obj">The object</param>
//        /// <returns>return true or false</returns>
//        public override bool Equals(object? obj)
//        {
//            return obj is Akiv position &&
//                   X == position.X &&
//                   Y == position.Y;
//        }


//        //TODO: Add a method to move the object in the game 
//        //TODO: Add a method to get the position of the object in the game

//        public static Akiv operator + (Akiv a, Akiv b)
//        {
//            return new Akiv(a.X + b.X, a.Y + b.Y);
//        }

//        public static Akiv operator - (Akiv a, Akiv b)
//        {
//            return new Akiv(a.X - b.X, a.Y - b.Y);
//        }

//        public static bool operator == (Akiv a, Akiv b)
//        {
//            return a.Equals(b);
//        }

//        public static bool operator != (Akiv a, Akiv b)
//        {
//            return !a.Equals(b);
//        }

//        public override string ToString()
//        {
//            return $"{{{nameof(X)}={X.ToString()}, {nameof(Y)}={Y.ToString()}}}";
//        }

//        public void Move(int x, int y)
//        {
//            X += x;
//            Y += y;
//        }



//    }
//}
