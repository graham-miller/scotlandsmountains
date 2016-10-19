namespace ScotlandsMountains.Domain
{
    public class Map : Entity
    {
        public string Publisher { get; set; }
        public string Series { get; set; }
        public string Code { get; set; }
        public string Isbn { get; set; }
        public decimal Scale { get; set; }
    }
}
