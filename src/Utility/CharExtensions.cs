using System.Globalization;
using System.Linq;

namespace ScotlandsMountains.Utility
{
    public static class CharExtensions
    {
        public static bool IsLetter(this char c)
        {
            return c.ToString(CultureInfo.InvariantCulture).ToUpper() != c.ToString(CultureInfo.InvariantCulture).ToLower();
        }

        public static bool IsNumber(this char c)
        {
            return new[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" }.Contains(c.ToString(CultureInfo.InvariantCulture));
        }
    }
}
