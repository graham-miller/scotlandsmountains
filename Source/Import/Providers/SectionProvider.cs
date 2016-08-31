using System.Collections.Generic;
using System.Linq;
using ScotlandsMountains.Domain;
using ScotlandsMountains.Import.Dobih;

namespace ScotlandsMountains.Import.Providers
{
    public class SectionProvider : IEntityProvider<Section>
    {
        public SectionProvider(IIdGenerator idGenerator, IDobihFile dobihFile)
        {
            _sections = LoadSections(idGenerator, dobihFile);
        }

        public IList<Section> GetAll()
        {
            return _sections.Select(x => x.Value).ToList();
        }

        public Section GetByDobihId(string dobihId)
        {
            return _sections[dobihId];
        }

        private static Dictionary<string, Section> LoadSections(IIdGenerator idGenerator, IDobihFile dobihFile)
        {
            return dobihFile.Records
                .Select(x => new { x.SectionCode, x.SectionName })
                .GroupBy(x => x.SectionName)
                .OrderBy(x => x.First().SectionCode)
                .ToDictionary(
                    x => x.First().SectionName,
                    x => new Section
                    {
                        Id = idGenerator.Generate(),
                        Name = x.First().SectionName
                    });
        }

        private readonly IDictionary<string, Section> _sections;
    }
}
