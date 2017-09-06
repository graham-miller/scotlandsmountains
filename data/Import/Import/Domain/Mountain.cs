using System.Collections.Generic;
using Newtonsoft.Json;

namespace ScotlandsMountains.Import.Domain
{
    public class Mountain : HasKey
    {
        public Mountain(DobihRecord dobihRecord)
        {
            DobihRecord = dobihRecord;

            Name = DobihRecord.CleanedName;
            Location = DobihRecord.Location;
            Height = DobihRecord.Height;
            Prominence = DobihRecord.Prominence;
            DobihNumber = DobihRecord.DobihNumber;
        }

        public string Name { get; set; }
        public Location Location { get; set; }
        public Height Height { get; set; }
        public Prominence Prominence { get; set; }
        public int DobihNumber { get; set; }
        public List<string> ClassificationIds { get; set; }
        public string SectionId { get; set; }
        public string CountryId { get; set; }
        public List<string> MapIds { get; set; }
        public string ParentId { get; set; }

        [JsonIgnore]
        public DobihRecord DobihRecord { get; set; }
    }
}
