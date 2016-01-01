using System.Collections.Generic;
using System.Linq;
using ScotlandsMountains.Domain;

namespace ScotlandsMountains.Import
{
    internal class AreaEntityFactory
    {
        public IList<Area> Areas { get; private set; }

        public AreaEntityFactory(IDobihReader records)
        {
            Areas = records.Records
                           .Select(x => x.Region)
                           .Distinct()
                           .OrderBy(x => x)
                           .Select(x => new Area { Name = x, Mountains = new List<Mountain>() })
                           .ToList();
        }
    }
}