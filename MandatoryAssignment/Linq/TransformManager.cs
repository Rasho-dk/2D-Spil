using MandatoryAssignment.Interfaces;
using System.Linq;

namespace MandatoryAssignment.Linq
{
    /// <summary>
    /// This class is used to transform a list of items to another list of items of a different type
    /// I used this class to Create a superCreature when the player has won against other creature/s
    /// </summary>
    public static class TransformManager
    {
        /// <summary>
        /// This method is used to transform a list of items to another list of items of a different type
        /// </summary>
        /// <typeparam name="T">This is the type of the items in the list</typeparam>
        /// <typeparam name="V">This is the type of the items in the transformed list (new)</typeparam>
        /// <param name="itmes">The list of items to transform</param>
        /// <param name="transformer">The transformer function to use to transform the items</param>
        /// <returns>Return the transformed list of items</returns>
        public static List<V> Trasform<T, V>(List<T> itmes, Func<T, V> transformer)
        {
            List<V> trasnsformedItmes = new List<V>();

            foreach (T item in itmes)
            {
                V transformedItem = transformer(item);
                trasnsformedItmes.Add(transformedItem);
            }

            return itmes.Select(transformer).ToList();
        }
        
    }
}

