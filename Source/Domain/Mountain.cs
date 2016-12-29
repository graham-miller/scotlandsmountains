using System.Collections.Generic;

namespace ScotlandsMountains.Domain
{
    public class Mountain : Entity
    {
        public Height Height { get; set; }
        public Location Location { get; set; }
        public Prominence Prominence { get; set; }
        public string Feature { get; set; }
        public string Observations { get; set; }

        public IList<string> ListIds { get; set; }
        public IList<string> MapIds { get; set; }
        public string SectionId { get; set; }
        public string CountryId { get; set; }
    }
}