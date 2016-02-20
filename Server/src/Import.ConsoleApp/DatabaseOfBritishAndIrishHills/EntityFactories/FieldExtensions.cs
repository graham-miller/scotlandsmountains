using System;
using System.Collections.Generic;
using System.Linq;

namespace ScotlandsMountains.Import.ConsoleApp.DatabaseOfBritishAndIrishHills.EntityFactories
{
    internal static class FieldExtensions
    {
        public static string SectionCode(this string s)
        {
            return s.SectionPart(0);
        }

        public static string SectionName(this string s)
        {
            var name = s.SectionPart(1);

            name = HandleDuplicateSectionNames(s.SectionCode(), name);

            return name;
        }

        private static string HandleDuplicateSectionNames(string code, string name)
        {
            if (new[] {"05A", "07A", "08A", "26A"}.Contains(code))
            {
                name += " (West)";
            }
            else if (new[] {"05B", "07B", "08B", "26B"}.Contains(code))
            {
                name += " (East)";
            }
            return name;
        }

        public static bool IsTrue(this string s)
        {
            return s == "1";
        }

        public static IEnumerable<string> SplitCounties(this string s)
        {
            return s.Split(new[] { "/" }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim());
        }

        public static IEnumerable<string> SplitMaps(this string s)
        {
            return s.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                .Where(x => x != "OL")
                .Select(x => x.Trim().RemoveTrailingLetters());
        }

        private static string SectionPart(this string s, int partIndex)
        {
            return s.Split(new[] { ":" }, StringSplitOptions.RemoveEmptyEntries)[partIndex].Trim();
        }

        private static string RemoveTrailingLetters(this string s)
        {
            var trimed = s;

            while (char.IsLetter(trimed.Last()))
                trimed = trimed.Substring(0, trimed.Length - 1);

            return trimed;
        }
    }
}
