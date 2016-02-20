using ScotlandsMountains.Domain.Calculations;

namespace ScotlandsMountains.Domain.ValueTypes
{
    public class Height
    {
        public double Metres { get; set; }

        public double Feet => Convert.ToFeetFrom(Metres);
    }
}