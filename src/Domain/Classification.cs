using System.Collections.Generic;

namespace ScotlandsMountains.Domain
{
    public class Classification : Entity
    {
        public virtual string Name { get; set; }
        public virtual IList<Mountain> Mountains { get; set; }
    }
}
