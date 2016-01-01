using System.Collections.Generic;

namespace ScotlandsMountains.Domain
{
    public class MapPublisher : Entity
    {
        public virtual string Name { get; set; }
        public virtual IList<MapSeries> MapSeries { get; set; }
    }
}