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
                Mountains = dobihRecords.Select(x => new Mountain(x)).ToList()
            };

            return root;
        }

        private Root() { }

        public List<Mountain> Mountains { get; set; }
    }
}
