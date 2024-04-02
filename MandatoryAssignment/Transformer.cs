using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryAssignment
{
    public class Transformer
    {
        public static List<V> Transformitems<T, V>(List<T> values, Func<T, V> transformer)
        {
            List<V> result = new List<V>();
            foreach (T item in values)
            {
                result.Add(transformer(item));
            }
            return result;
        }
    }
}
