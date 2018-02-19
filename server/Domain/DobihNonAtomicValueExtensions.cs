using System;
using System.Collections.Generic;
using System.Linq;

namespace ScotlandsMountains.Domain
{
    public static class DobihNonAtomicValueExtensions
    {
        public static List<string> SplitClassificationCodes(this string s)
        {
            return s.SplitCharSeparatedString(',').ToList();
        }

        public static List<string> SplitMapCodes(this string s)
        {
            return s.SplitCharSeparatedString(' ').Select(x => x.TrimStart('0')).ToList();
        }

        private static IEnumerable<string> SplitCharSeparatedString(this string s, char c)
        {
            return s.Split(new[] { c }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
