namespace ScotlandsMountains.Domain.Entities
{
    public class Map : Entity
    {
        public Map() { }

        public Map(string publisher, decimal scale, int code)
        {
            Publisher = publisher;
            Scale = scale;
            Code = code;
        }
        
        public virtual string Publisher { get; set; }
        public virtual string Description { get; set; }
        public virtual decimal Scale { get; set; }
        public virtual int Code { get; set; }        
    }
}
