using System;
using System.Collections.Generic;

namespace ScotlandsMountains.Domain
{
    public class Map : Entity
    {
        public virtual MapPublisher Publisher { get; set; }
        public virtual MapSeries Series { get; set; }
        public virtual string Sheet { get; set; }
        public virtual string Name { get; set; }
        public virtual decimal Scale { get; set; }
        public virtual string Isbn { get; set; }
        public virtual DateTime PublicationDate { get; set; }
        public virtual string Edition { get; set; }
        public virtual IList<Mountain> Mountains { get; set; }
    }
}
