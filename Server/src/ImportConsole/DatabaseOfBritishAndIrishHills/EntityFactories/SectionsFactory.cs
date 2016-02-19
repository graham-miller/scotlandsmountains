using System.Collections.Generic;
using System.Linq;
using ScotlandsMountains.Domain.Entities;

namespace ScotlandsMountains.ImportConsole.DatabaseOfBritishAndIrishHills.EntityFactories
{
    public class SectionsFactory
    {
        public SectionsFactory(IEnumerable<Record> records)
        {
            Sections = records
                .Select(r => new
                {
                    Code = r[Field.Section],
                    Name = r[Field.SectionName].SectionName()
                })
                .Distinct()
                .OrderBy(x => x.Code)
                .Select((x, i) => new Section
                {
                    Id = i+1,
                    Code = x.Code,
                    Name = x.Name
                })
                .ToList();
        }

        public IList<Section> Sections { get; private set; }
    }
}