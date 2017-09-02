namespace ScotlandsMountains.Import.Domain
{
    public class Height
    {
        public double Metres { get; set; }
        public double Feet => Metres / 0.3048;
    }
}