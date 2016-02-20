using Newtonsoft.Json;
using System;

namespace ScotlandsMountains.Domain.Entities
{
    public abstract class Entity
    {
        protected Entity()
        {
            Key = Guid.NewGuid().ToString("N");
        }

        [JsonIgnore]
        public string Key { get; set; }
    }
}
