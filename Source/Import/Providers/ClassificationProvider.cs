using System.Collections.Generic;
using System.Linq;
using ScotlandsMountains.Domain;
using ScotlandsMountains.Import.Dobih;
using ScotlandsMountains.Import.ScotlandsMountains;

namespace ScotlandsMountains.Import.Providers
{
    public class ClassificationProvider : IEntityProvider<Classification>
    {
        public ClassificationProvider(IIdGenerator idGenerator, IDobihFile dobihFile, IClassificationInfoProvider classificationInfoProvider)
        {
            _classifications = LoadClassifications(idGenerator, dobihFile, classificationInfoProvider);
        }

        public IList<Classification> GetAll()
        {
            return _classifications.Select(x => x.Value).OrderBy(x => x.Order).ToList();
        }

        public Classification GetByDobihId(string dobihId)
        {
            return _classifications[dobihId];
        }

        private static Dictionary<string, Classification> LoadClassifications(IIdGenerator idGenerator, IDobihFile dobihFile, IClassificationInfoProvider classificationInfoProvider)
        {
            return dobihFile.Records
                .SelectMany(x => x.Classifications)
                .Distinct()
                .ToDictionary(
                    x => x,
                    x => new Classification
                    {
                        Id = idGenerator.Generate(),
                        Name = classificationInfoProvider.GetClassificationInfoFor(x).Name,
                        Order = classificationInfoProvider.GetClassificationInfoFor(x).Order,
                        Description = classificationInfoProvider.GetClassificationInfoFor(x).Description
                    });
        }

        private readonly IDictionary<string, Classification> _classifications;
    }
}
