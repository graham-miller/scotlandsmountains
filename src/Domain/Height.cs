namespace ScotlandsMountains.Domain
{
    public class Height
    {
        public virtual decimal Metres { get; set; }
        public decimal Feet { get { return Metres * 3.2808399m; } }
    }
}