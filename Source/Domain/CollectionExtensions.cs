using System;
using System.Collections.Generic;
using System.Linq;

namespace ScotlandsMountains.Domain
{
    public static class CollectionExtensions
    {
        public static T GetById<T>(this IEnumerable<T> collection, string id) where T : Entity
        {
            return collection.FirstOrDefault(x => x.Id == id);
        }

        public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action) where T : Entity
        {
            foreach (var item in collection)
                action(item);
        }
    }
}
