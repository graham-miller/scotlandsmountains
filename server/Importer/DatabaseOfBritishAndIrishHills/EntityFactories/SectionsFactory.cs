using System.Collections.Generic;
using System.Linq;
using ScotlandsMountains.Domain.Entities;

namespace ScotlandsMountains.Importer.DatabaseOfBritishAndIrishHills.EntityFactories
{
    public class SectionsFactory
    {
        public SectionsFactory(IEnumerable<Record> records, HashIds hashIds)
        {
            Sections = records
                .Select(r => new
                {
                    Code = r[Field.Section],
                    Name = r[Field.SectionName].SectionName()
                })
                .Distinct()
                .OrderBy(x => x.Code)
                .Select(x => new Section
                {
                    Key = hashIds.Next(),
                    Code = x.Code,
                    Name = x.Name
                })
                .ToList();
        }

        public IList<Section> Sections { get; private set; }
    }
}