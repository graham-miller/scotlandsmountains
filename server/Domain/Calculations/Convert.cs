using System;

namespace ScotlandsMountains.Domain.Calculations
{
    public static class Convert
    {
        private const double FeetPerMetre = 3.28084;

        public static double ToFeetFrom(double metres, int? decimalPlaces = 0)
        {
            return Math.Round(metres*FeetPerMetre, decimalPlaces ?? 0, MidpointRounding.AwayFromZero);
        }
    }
}