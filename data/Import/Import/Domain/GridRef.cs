using System;
using System.Text.RegularExpressions;

namespace ScotlandsMountains.Import.Domain
{
    public class GridRef
    {
        private static readonly Regex SixFigureGridRefRegex = new Regex("^[A-Z]{2}[0-9]{6}$");
        private static readonly Regex TenFigureGridRefRegex = new Regex("^[A-Z]{2}[0-9]{10}$");

        public GridRef(string sixFigure, string tenFigure = null)
        {
            if (SixFigureGridRefRegex.IsMatch(sixFigure))
            {
                SixFigure = sixFigure;
            }
            else
            {
                throw new ArgumentOutOfRangeException($"{sixFigure} is not a valid six-figure grid reference");
            }

            if (tenFigure == null)
            {
                TenFigure = $"{sixFigure.Substring(0, 5)}00{sixFigure.Substring(5, 3)}00";
            }
            else
            {
                if (!TenFigureGridRefRegex.IsMatch(tenFigure))
                    throw new ArgumentOutOfRangeException($"{tenFigure} is not a valid ten-figure grid reference");

                TenFigure = tenFigure;
            }

        }

        public string SixFigure { get; set; }
        public string TenFigure { get; set; }
    }
}