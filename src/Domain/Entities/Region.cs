using System.Collections.Generic;

namespace ScotlandsMountains.Domain.Entities
{
    public class Region : Entity
    {
        protected Region()
        {
            Mountains = new List<Mountain>();
        }

        public Region(string name) : this()
        {
            Name = name;
        }

        public string Name { get; set; }

        public ICollection<Mountain> Mountains { get; set; }
    }
}
