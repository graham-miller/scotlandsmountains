using ScotlandsMountains.Domain.Calculations;

namespace ScotlandsMountains.Domain.ValueTypes
{
    public class Height
    {
        public decimal Metres { get; set; }

        public decimal Feet => Convert.ToFeetFrom(Metres);
    }
}