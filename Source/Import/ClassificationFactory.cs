using System.Collections.Generic;
using System.Linq;
using ScotlandsMountains.Domain;
using ScotlandsMountains.Import.Dobih;

namespace ScotlandsMountains.Import
{
    class ClassificationFactory
    {
        private readonly IIdGenerator _idGenerator;

        public ClassificationFactory(IIdGenerator idGenerator)
        {
            _idGenerator = idGenerator;
        }

        public IList<Classification> BuildFrom(IDobihFile dobihFile)
        {
            return dobihFile.Records
                .SelectMany(x => x.Classifications)
                .Distinct()
                .Select(x => new Classification
                {
                    Id = _idGenerator.Generate(),
                    Name = x
                })
                .OrderBy(x => x.Name)
                .ToList();
        }


    }
}
