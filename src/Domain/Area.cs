using System.Collections.Generic;

namespace ScotlandsMountains.Domain
{
    public class Area : Entity
    {
        public virtual string Name { get; set; }
        public virtual IList<Mountain> Mountains { get; set; }
    }
}
