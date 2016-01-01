using System.Collections.Generic;

namespace ScotlandsMountains.Domain.Entities
{
    public class Table : Entity
    {
        public Table()
        {
            Mountains = new List<Mountain>();
        }

        public virtual string Name { get; set; }
        public virtual IList<Mountain> Mountains { get; set; }
    }
}
