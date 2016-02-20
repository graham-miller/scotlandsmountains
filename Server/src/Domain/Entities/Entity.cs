using System;

namespace ScotlandsMountains.Domain.Entities
{
    public abstract class Entity
    {
        protected Entity()
        {
            Key = Guid.NewGuid().ToString("N");
        }

        public string Key { get; set; }
    }
}
