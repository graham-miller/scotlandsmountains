using System.Collections.Generic;
using ScotlandsMountains.Domain.ValueTypes;

namespace ScotlandsMountains.Domain.Entities
{
    public class Mountain : Entity
    {
        public virtual string Name { get; set; }
        public virtual Height Height { get; set; }
        public virtual Location Location { get; set; }
        public virtual IList<Map> Maps { get; set; }
        public virtual Summit Summit { get; set; }
        public virtual int DobihId { get; set; }
        public virtual Mountain Parent { get; set; }
        public virtual IList<Table> Tables { get; set; }
    }
}
