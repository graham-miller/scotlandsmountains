using System;

namespace ScotlandsMountains.Domain.ValueObjects
{
    public class Height : IComparable<Height>, IEquatable<Height>
    {
        protected Height() { }

        public Height(double heightInMetres)
        {
            Metres = heightInMetres;
        }

        public double Metres { get; set; }
        public double Feet { get { return Math.Round(Metres / 0.3048, MidpointRounding.AwayFromZero); }
        }

        #region IComparable<Height>

        public int CompareTo(Height other)
        {
            return Metres.CompareTo(other.Metres);
        }

        #endregion

        #region IComparable<Height>

        public bool Equals(Height other)
        {
            return Metres.Equals(other.Metres);
        }

	    #endregion
    }
}