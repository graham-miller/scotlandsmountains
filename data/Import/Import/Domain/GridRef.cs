using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace ScotlandsMountains.Import.Domain
{
    public class GridRef
    {
        private const string GridLetters = "GridLetters";
        private const string Eastings = "Eastings";
        private const string Northings = "Northings";
        private const string BaseRegex =
            "^(?<" + GridLetters + ">[A-Z]{{1,2}}) *" +
            "(?<" + Eastings + ">[0-9]{{{0}}}) *" +
            "(?<" + Northings + ">[0-9]{{{0}}})$";

        private static readonly Regex SixFigureGridRefRegex = new Regex(string.Format(BaseRegex, 3));
        private static readonly Regex EightFigureGridRefRegex = new Regex(string.Format(BaseRegex, 4));
        private static readonly Regex TenFigureGridRefRegex = new Regex(string.Format(BaseRegex, 5));

        public static bool IsGridRef(string s)
        {
            return IsSixFigureGridRef(s) || IsEightFigureGridRef(s) || IsTenFigureGridRef(s);
        }

        public static bool IsSixFigureGridRef(string s)
        {
            return SixFigureGridRefRegex.IsMatch(s);
        }

        public static bool IsEightFigureGridRef(string s)
        {
            return EightFigureGridRefRegex.IsMatch(s);
        }

        public static bool IsTenFigureGridRef(string s)
        {
            return TenFigureGridRefRegex.IsMatch(s);
        }

        public GridRef(params string[] args)
        {
            var sixFigure = args.FirstOrDefault(IsSixFigureGridRef);
            if (sixFigure != null)
            {
                var match = SixFigureGridRefRegex.Match(sixFigure);
                SixFigure = match.Groups[GridLetters].Value + match.Groups[Eastings].Value + match.Groups[Northings].Value;
            }

            var eightFigure = args.FirstOrDefault(IsEightFigureGridRef);
            if (eightFigure != null)
            {
                var match = EightFigureGridRefRegex.Match(eightFigure);
                if (SixFigure == null)
                {
                    SixFigure = match.Groups[GridLetters].Value + match.Groups[Eastings].Value.Substring(0,3) + match.Groups[Northings].Value.Substring(0, 3);
                }
                TenFigure = match.Groups[GridLetters].Value + match.Groups[Eastings].Value + "0" + match.Groups[Northings].Value + "0";
            }

            var tenFigure = args.FirstOrDefault(IsTenFigureGridRef);
            if (tenFigure != null)
            {
                var match = TenFigureGridRefRegex.Match(tenFigure);
                if (SixFigure == null)
                {
                    SixFigure = match.Groups[GridLetters].Value + match.Groups[Eastings].Value.Substring(0, 3) + match.Groups[Northings].Value.Substring(0, 3);
                }
                TenFigure = match.Groups[GridLetters].Value + match.Groups[Eastings].Value + match.Groups[Northings].Value;
            }

            if (SixFigure == null)
                throw new ArgumentException("GridRef could not be constructed");

            if (TenFigure == null)
            {
                var match = SixFigureGridRefRegex.Match(SixFigure);
                TenFigure = match.Groups[GridLetters].Value + match.Groups[Eastings].Value + "00" + match.Groups[Northings].Value + "00";
            }
        }

        public string SixFigure { get; set; }
        public string TenFigure { get; set; }
    }
}