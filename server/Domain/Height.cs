using System;

namespace ScotlandsMountains.Domain
{
    public class Height
    {
        public double Metres { get; set; }
        public double Feet => Math.Round(Metres / 0.3048, MidpointRounding.AwayFromZero);
    }
}