using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace de.efsdev.wsapm.OpenNetworkConnections.Library.Extensions
{
    public static class CollectionExtension
    {
        public static void RemoveAll<T>(this ICollection<T> collection, Func<T, bool> condition)
        {
            foreach (var item in collection)
            {
                if (condition.Invoke(item))
                {
                    collection.Remove(item);
                }
            }
        }
    }
}
