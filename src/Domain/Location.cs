namespace ScotlandsMountains.Domain
{
    public class Location
    {
        public virtual string GridReference { get; set; }
        public virtual decimal Latitude { get; set; }
        public virtual decimal Longitude { get; set; }
    }
}