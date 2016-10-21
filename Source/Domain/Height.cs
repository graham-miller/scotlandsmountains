using System;
using Newtonsoft.Json;

namespace ScotlandsMountains.Domain
{
    public class Height : IComparable<Height>
    {
        public const double MetresToFeetConversionFactor = 1 / 0.3048;

        public double Metres
        {
            get { return _metres; }
            set
            {
                _metres = Math.Round(value, 1, MidpointRounding.AwayFromZero);
                _feet = Math.Round(_metres * MetresToFeetConversionFactor, 1, MidpointRounding.AwayFromZero);
            }
        }

        [JsonIgnore]
        public double Feet
        {
            get { return _feet; }
            set
            {
                _feet = Math.Round(value, 1, MidpointRounding.AwayFromZero);
                _metres = Math.Round(_feet / MetresToFeetConversionFactor, 1, MidpointRounding.AwayFromZero);
            }
        }

        public int CompareTo(Height other)
        {
            return Metres.CompareTo(other.Metres);
        }

        public override string ToString()
        {
            return $"{Metres.ToString("#,##0")}m ({Feet.ToString("#,##0")}ft)";
        }

        private double _feet;
        private double _metres;
    }
}