using System.Collections.Generic;

namespace ScotlandsMountains.Domain
{
    public class Mountain : Entity
    {
        public virtual string Name { get; set; }
        public virtual string SummitDescription { get; set; }
        public virtual string SummitDetails { get; set; }
        public virtual Mountain Parent { get; set; }
        public virtual IList<Mountain> Children { get; set; }
        public virtual Area Area { get; set; }
        public virtual Height Height { get; set; }
        public virtual Prominence Prominence { get; set; }
        public virtual Location Location { get; set; }
        public virtual Country Country { get; set; }
        public virtual IList<Map> Maps { get; set; }
        public virtual IList<Classification> Classifications { get; set; }
        public virtual int DobihNumber { get; set; }
    }
}
