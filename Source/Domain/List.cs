namespace ScotlandsMountains.Domain
{
    public class List : Entity
    {
        public int Order { get; set; }
        public string Description { get; set; }
        public bool Enabled { get; set; }
    }
}