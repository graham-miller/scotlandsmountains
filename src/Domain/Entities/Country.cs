using System.Collections.Generic;

namespace ScotlandsMountains.Domain.Entities
{
    public class Country : Entity
    {
        protected Country()
        {
            Mountains = new List<Mountain>();
        }

        public Country(string name) : this()
        {
            Name = name;
        }

        public string Name { get; set; }

        public ICollection<Mountain> Mountains { get; set; }
    }
}
