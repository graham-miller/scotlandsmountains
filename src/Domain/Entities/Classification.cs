using System.Collections.Generic;

namespace ScotlandsMountains.Domain.Entities
{
    public class Classification : Entity
    {
        protected Classification()
        {
            Mountains = new List<Mountain>();
        }

        public Classification(string name) : this()
        {
            Name = name;
        }

        public string Name { get; set; }

        public ICollection<Mountain> Mountains { get; set; }
    }
}
