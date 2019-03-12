using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace  System.Collections.Generic
{
   public static class CollectionExtension
    {
        public static bool IsNullOrEmpty<T>(this List<T> collection)
        {
            if (collection != null)
            {
                if (collection.Count == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }
    }
}
