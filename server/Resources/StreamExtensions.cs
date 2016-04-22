using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ScotlandsMountains.Resources
{
    public static class StreamExtensions
    {
        public static string[] ReadAllLines(this Stream stream)
        {
            return stream.ReadLines().ToArray();
        }

        private static IEnumerable<string> ReadLines(this Stream stream)
        {
            using (var reader = new StreamReader(stream))
            {
                while (!reader.EndOfStream)
                    yield return reader.ReadLine();
            }
        }
    }
}
