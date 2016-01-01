using System.Collections.Generic;

namespace ScotlandsMountains.Data.Extensions
{
// ReSharper disable InconsistentNaming
    public static class IEnumerableOfTExtensions
// ReSharper restore InconsistentNaming
    {
        public static IEnumerable<IEnumerable<T>> Partition<T>(this IEnumerable<T> sequence, int size)
        {
            var partition = new List<T>(size);
            foreach (var item in sequence)
            {
                partition.Add(item);
                if (partition.Count != size) continue;
                
                yield return partition;
                partition = new List<T>(size);
            }

            if (partition.Count > 0)
                yield return partition;
        }
    }
}
