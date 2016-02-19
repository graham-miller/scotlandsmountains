using ScotlandsMountains.Domain.Calculations;

namespace ScotlandsMountains.Domain.ValueTypes
{
    public class Prominence
    {
        public decimal Metres { get; set; }

        public decimal Feet => Convert.ToFeetFrom(Metres);

        public KeyCol KeyCol { get; set; }
    }
}