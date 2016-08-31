using System;
using System.Text.RegularExpressions;

namespace ScotlandsMountains.Domain
{
    public class GridRef
    {
        public GridRef() { }

        public GridRef(string raw)
        {
            SetProperties(raw);
        }

        public string SixFigure { get; set; }

        public string TenFigure { get; set; }

        private void SetProperties(string raw)
        {
            if (SixDigitOsGridRefRegex.IsMatch(raw))
            {
                SixFigure = raw;
                TenFigure = $"{raw.Substring(0, 5)}00{raw.Substring(5)}00";
            }
            else if (TenDigitOsGridRefRegex.IsMatch(raw))
            {
                SixFigure = $"{raw.Substring(0, 5)}{raw.Substring(7, 3)}";
                TenFigure = raw;
            }
            else if (SixDigitIrishGridRefRegex.IsMatch(raw))
            {
                SixFigure = raw;
                TenFigure = $"{raw.Substring(0, 4)}00{raw.Substring(4)}00";
            }
            else if (TenDigitIrishGridRefRegex.IsMatch(raw))
            {
                SixFigure = $"{raw.Substring(0, 4)}{raw.Substring(6, 3)}";
                TenFigure = raw;
            }
            else
            {
                throw new ArgumentException($"{raw} is not a valid grid reference.");
            }
        }

        public static bool IsValid(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return false;

            return
                SixDigitOsGridRefRegex.IsMatch(s) ||
                TenDigitOsGridRefRegex.IsMatch(s) ||
                SixDigitIrishGridRefRegex.IsMatch(s) ||
                TenDigitIrishGridRefRegex.IsMatch(s);
        }

        private static readonly Regex SixDigitOsGridRefRegex = new Regex(@"^[STNHOW][ABCDEFGHJKLMNOPQRSTUVWXYZ]\d{6}$");
        private static readonly Regex TenDigitOsGridRefRegex = new Regex(@"^[STNHOW][ABCDEFGHJKLMNOPQRSTUVWXYZ]\d{10}$");
        private static readonly Regex SixDigitIrishGridRefRegex = new Regex(@"^[BCDFGHJLMNOQRSTVWXZ]\d{6}$");
        private static readonly Regex TenDigitIrishGridRefRegex = new Regex(@"^[BCDFGHJLMNOQRSTVWXZ]\d{10}$");
    }
}