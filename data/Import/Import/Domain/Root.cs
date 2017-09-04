using System.Collections.Generic;
using System.Linq;

namespace ScotlandsMountains.Import.Domain
{
    public class Root
    {
        public static Root Build(IList<DobihRecord> dobihRecords)
        {
            var root = new Root
            {
                Mountains = dobihRecords.Select(x => new Mountain(x)).ToList(),
                Sections = dobihRecords.Select(x => x.SectionName).Distinct().Select(x => new Section(x)).ToList(),
                Classifications = Classification.Build()
            };

            //TODO
            // Create maps
            // Create countries
            // Link mountain and Parent (SMC) and Parent (Ma), 
            // Link mountain and classifications
            // Link mountain and sections
            // Link mountain and maps
            // Link mountain and countries


            return root;
        }

        private Root() { }

        public List<Mountain> Mountains { get; set; }
        public List<Section> Sections { get; set; }
        public IList<Classification> Classifications { get; set; }
    }
}
