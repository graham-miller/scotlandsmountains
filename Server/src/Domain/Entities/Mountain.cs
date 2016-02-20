using ScotlandsMountains.Domain.ValueTypes;

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

        public string SectionKey { get; set; }

        public string IslandKey { get; set; }

        public string[] CountyKeys { get; set; }

        public string TopologicalSectionKey { get; set; }

        public string[] MapKeys { get; set; }

        public string[] ClassificationKeys { get; set; }
    }

    public class MountainSummary : Entity
    {
        public object[] Data { get; set; }
    }
}
