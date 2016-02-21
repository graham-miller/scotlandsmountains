using System.Collections.Generic;

namespace ScotlandsMountains.Domain.Entities
{
    public abstract class MountainContainer : Entity
    {
        public IList<Mountain> Mountains { get; set; } = new List<Mountain>();
    }
}
