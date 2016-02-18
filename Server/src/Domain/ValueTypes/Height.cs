using System;

namespace ScotlandsMountains.Domain.ValueTypes
{
    public class Height
    {
        public const decimal FeetPerMetre = 3.28084m;

        public decimal Metres { get; set; }

        public decimal Feet { get { return Math.Round(Metres * FeetPerMetre); } }
    }
}