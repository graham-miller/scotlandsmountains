using ScotlandsMountains.Domain.ValueTypes;
using System.Collections.Generic;

namespace ScotlandsMountains.Domain.Entities
{
    public class Mountain : Entity
    {
        public string DobihId { get; set; }

        public string Name { get; set; }

        public Height Height { get; set; }

        public Location Location { get; set; }

        public string SummitFeature { get; set; }

        public string SummitObservations { get; set; }

        public Prominence Prominence { get; set; }

        public Section Section { get; set; }

        public Island Island { get; set; }

        public IList<County> Counties { get; set; } = new List<County>();

        public TopologicalSection TopologicalSection { get; set; }

        public IList<Map> Maps { get; set; } = new List<Map>();

        public IList<Classification> Classifications { get; set; } = new List<Classification>();
    }
}
