using System;

namespace ScotlandsMountains.Domain.Entities
{
    public abstract class Entity
    {
        protected Entity()
        {
            Key = GetNewKey();
        }

        public string Key { get; set; }

        private static string GetNewKey()
        {
            return Guid.NewGuid().ToString("N");
        }
    }
}
