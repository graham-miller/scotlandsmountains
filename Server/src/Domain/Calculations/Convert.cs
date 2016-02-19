using System;

namespace ScotlandsMountains.Domain.Calculations
{
    public static class Convert
    {
        private const decimal FeetPerMetre = 3.28084m;

        public static decimal ToFeetFrom(decimal metres, int? decimalPlaces = 0)
        {
            return Math.Round(metres*FeetPerMetre, decimalPlaces ?? 0, MidpointRounding.AwayFromZero);
        }
    }
}