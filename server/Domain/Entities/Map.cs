namespace ScotlandsMountains.Domain.Entities
{
    public class Map : MountainContainer
    {
        public string Publisher { get; set; }

        public string Series { get; set; }

        public decimal Scale { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Isbn { get; set; }
    }
}
