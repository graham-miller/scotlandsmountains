using System.Collections.Generic;
using System.Linq;
using ScotlandsMountains.Domain.Entities;

namespace ScotlandsMountains.ImportConsole.DatabaseOfBritishAndIrishHills.EntityFactories
{
    public class TopologicalSectionsFactory
    {
        public TopologicalSectionsFactory(IEnumerable<Record> records)
        {
            TopologicalSections = records
                .Select(r => new
                {
                    Code = r[Field.TopoSection].SectionCode(),
                    Name = r[Field.TopoSection].SectionName()
                })
                .Distinct()
                .OrderBy(x => x.Code)
                .Select((x, i) => new TopologicalSection
                {
                    Id = i + 1,
                    Code = x.Code,
                    Name = x.Name
                })
                .ToList();
        }

        public IList<TopologicalSection> TopologicalSections { get; private set; }
    }
}