using ScotlandsMountains.Domain.Calculations;

namespace ScotlandsMountains.Domain.ValueTypes
{
    public class Prominence
    {
        public double Metres { get; set; }

        public double Feet => Convert.ToFeetFrom(Metres);

        public KeyCol KeyCol { get; set; }
    }
}