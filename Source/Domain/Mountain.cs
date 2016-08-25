using System.Collections.Generic;

namespace ScotlandsMountains.Domain
{
    public class Mountain : Entity
    {
        public string Name { get; set; }
        public Height Height { get; set; }
        public Location Location { get; set; }
        public IList<string> MapIds { get; set; } 
    }
}