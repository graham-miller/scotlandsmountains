using System.Collections.Generic;
using System.Linq;
using ScotlandsMountains.Domain;
using ScotlandsMountains.Import.Dobih;
using ScotlandsMountains.Import.ScotlandsMountains;

namespace ScotlandsMountains.Import
{
    public class ClassificationFactory
    {
        public ClassificationFactory(IIdGenerator idGenerator, IClassificationInfoProvider classificationInfoProvider)
        {
            _idGenerator = idGenerator;
            _classificationInfoProvider = classificationInfoProvider;
        }

        public IList<Classification> BuildFrom(IDobihFile dobihFile)
        {
            return dobihFile.Records
                .SelectMany(x => x.Classifications)
                .Distinct()
                .Select(x => _classificationInfoProvider.GetClassificationInfoFor(x))
                .OrderBy(x => x.Order)
                .Select(x => new Classification
                {
                    Id = _idGenerator.Generate(),
                    Name = x.Name,
                    Order  = x.Order,
                    Description = x.Description
                })
                .ToList();
        }

        private readonly IIdGenerator _idGenerator;
        private readonly IClassificationInfoProvider _classificationInfoProvider;
    }
}
