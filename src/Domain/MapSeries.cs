using System.Collections.Generic;

namespace ScotlandsMountains.Domain
{
    public class MapSeries : Entity
    {
        public virtual string Name { get; set; }
        public virtual IList<Map> Maps { get; set; }
    }
}