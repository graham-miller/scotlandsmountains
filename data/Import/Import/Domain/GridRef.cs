using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace ScotlandsMountains.Import.Domain
{
    public class GridRef
    {
        private static readonly Regex SixFigureGridRefRegex = new Regex("^[A-Z]{2} *[0-9]{3} *[0-9]{3}$");
        private static readonly Regex EightFigureGridRefRegex = new Regex("^[A-Z]{2} *[0-9]{4} *[0-9]{4}$");
        private static readonly Regex TenFigureGridRefRegex = new Regex("^[A-Z]{2} *[0-9]{5} *[0-9]{5}$");

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
                SixFigure = RemoveSpaces(sixFigure);

            var eightFigure = args.FirstOrDefault(IsEightFigureGridRef);
            if (eightFigure != null)
            {
                eightFigure = RemoveSpaces(eightFigure);
                SixFigure = $"{eightFigure.Substring(0, 5)}{eightFigure.Substring(6, 3)}";
                TenFigure = $"{eightFigure.Substring(0, 6)}0{eightFigure.Substring(6, 4)}0";
            }

            var tenFigure = args.FirstOrDefault(IsTenFigureGridRef);
            if (tenFigure != null)
            {
                TenFigure = RemoveSpaces(tenFigure);
                if (sixFigure == null)
                    SixFigure = $"{TenFigure.Substring(0, 5)}{TenFigure.Substring(7, 3)}";
            }

            if (SixFigure == null)
                throw new ArgumentException("GridRef could not be constructed");

            if (TenFigure == null)
                TenFigure = $"{SixFigure.Substring(0, 5)}00{SixFigure.Substring(5, 3)}00";
        }

        private string RemoveSpaces(string s)
        {
            return s.Replace(" ", "");
        }

        public string SixFigure { get; set; }
        public string TenFigure { get; set; }
    }
}