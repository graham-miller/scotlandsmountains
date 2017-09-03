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

            return root;
        }

        private Root() { }

        public List<Mountain> Mountains { get; set; }
        public List<Section> Sections { get; set; }
        public IList<Classification> Classifications { get; set; }
    }
}
