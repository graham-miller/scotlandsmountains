using System.Collections.Generic;

namespace ScotlandsMountains.Domain.Entities.Maps
{
    public abstract class Map : Entity
    {
        protected Map()
        {
            Mountains = new List<Mountain>();
        }

        protected Map(string code, string name, string isbn) : this()
        {
            Code = code;
            Name = name;
            Isbn = isbn;
        }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Isbn { get; set; }

        public abstract decimal Scale { get; }

        public abstract string Publisher { get; }
        
        public abstract string Series { get; }
        
        public ICollection<Mountain> Mountains { get; set; }
    }
}
