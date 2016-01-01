using System;
using System.Linq;
using ScotlandsMountains.Domain.ValueObjects;

namespace ScotlandsMountains.Data.Seeding.DatabaseOfBritishAndIrishHills.Factories
{
    internal static class ProminenceFactory
    {
        public static Prominence Build(double prominence, string measuredFrom, double measuredFromHeight)
        {
            return new Prominence
                {
                    Height = new Height(prominence),
                    Above = BuildMeasuredFrom(measuredFrom, measuredFromHeight)
                };
        }

        private static Above BuildMeasuredFrom(string measuredFrom, double measuredFromHeight)
        {
            return new Above
                {
                    Height = new Height(measuredFromHeight),
                    SixFigureGridReference = ExtractSixFigureGridReferenceFrom(measuredFrom),
                    TenFigureGridReference = ExtractTenFigureGridReferenceFrom(measuredFrom),
                    Feature = ExtractFeatureFrom(measuredFrom)
                };
        }

        private static string ExtractSixFigureGridReferenceFrom(string measuredFrom)
        {
            return IsGridReference(measuredFrom) ? ConvertToSixFigureGridReference(measuredFrom) : null;
        }

        private static string ExtractTenFigureGridReferenceFrom(string measuredFrom)
        {
            return IsTenFigureGridReference(measuredFrom) ? measuredFrom.Replace(" ", "") : null;
        }

        private static string ExtractFeatureFrom(string measuredFrom)
        {
            return IsGridReference(measuredFrom) ? null : measuredFrom;
        }

        private static bool IsTenFigureGridReference(string measuredFrom)
        {
            return IsGridReference(measuredFrom) && (measuredFrom.Replace(" ", "").Length == 11 || measuredFrom.Replace(" ", "").Length == 12);
        }

        private static bool IsGridReference(string measuredFrom)
        {
            return !String.IsNullOrWhiteSpace(measuredFrom) && Char.IsNumber(measuredFrom.Last());
        }

        private static string ConvertToSixFigureGridReference(string gridReference)
        {
            const int sixFigureEastingLength = 3;

            var letters = new String(gridReference.Where(Char.IsLetter).ToArray());
            var numbers = new String(gridReference.Where(Char.IsNumber).ToArray());
            var eastingLength = numbers.Length/2;
            var factor = (Decimal)Math.Pow(10, eastingLength - sixFigureEastingLength);
            var easting = Decimal.Parse(numbers.Substring(0, eastingLength)) / factor;
            var northing = Decimal.Parse(numbers.Substring(eastingLength)) / factor;

            // prevent rounding returning 4 digit number
            easting = easting >= 999 ? 999 : easting;
            northing = northing >= 999 ? 999 : northing;

            var sixFigureGridReference = String.Format(
                "{0}{1}{2}",
                letters,
                Math.Round(easting, 0, MidpointRounding.AwayFromZero).ToString("000"),
                Math.Round(northing, 0, MidpointRounding.AwayFromZero).ToString("000"));

            if (sixFigureGridReference.Length > 8)
                throw new Exception("\"" + gridReference + "\" cannot be converted to a six-figure gridreference.");

            return sixFigureGridReference;
        }
    }
}
