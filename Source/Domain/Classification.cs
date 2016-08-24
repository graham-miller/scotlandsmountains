namespace ScotlandsMountains.Domain
{
    public class Classification : Entity
    {
        public string Name { get; set; }
        public int Order { get; set; }
        public string Description { get; set; }
    }
}