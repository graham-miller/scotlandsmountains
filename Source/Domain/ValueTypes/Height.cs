using System;

namespace ScotlandsMountains.Domain.ValueTypes
{
    public class Height
    {
        public Height() { }

        public Height(decimal heightInFeet)
        {
            Feet = heightInFeet;
        }

        private decimal _feet;
        public decimal Feet
        {
            get { return _feet; }
            private set
            {
                _feet = value;
                Metres = Math.Round(Decimal.Multiply(Feet, 0.3048m), MidpointRounding.AwayFromZero);
            }
        }

        public decimal Metres { get; protected set; }
    }
}