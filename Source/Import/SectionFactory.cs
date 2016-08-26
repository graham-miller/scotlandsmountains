using System.Collections.Generic;
using System.Linq;
using ScotlandsMountains.Domain;
using ScotlandsMountains.Import.Dobih;

namespace ScotlandsMountains.Import
{
    public class SectionFactory
    {
        public SectionFactory(IIdGenerator idGenerator)
        {
            _idGenerator = idGenerator;
        }

        public IList<Section> BuildFrom(IDobihFile dobihFile)
        {
            return dobihFile.Records
                .Select(x => new { x.SectionCode, x.SectionName })
                .GroupBy(x => x.SectionName)
                .OrderBy(x => x.First().SectionCode)
                .Select(x => x.Key)
                .Select(x => new Section
                {
                    Id = _idGenerator.Generate(),
                    Name = x
                })
                .ToList();
        }

        private readonly IIdGenerator _idGenerator;
    }
}
