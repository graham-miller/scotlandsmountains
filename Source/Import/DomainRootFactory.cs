using System.Collections.Generic;
using System.Linq;
using ScotlandsMountains.Domain;
using ScotlandsMountains.Import.Dobih;
using ScotlandsMountains.Import.Os;

namespace ScotlandsMountains.Import
{
    public class DomainRootFactory
    {
        public DomainRootFactory(IDobihFile dobihFile = null, IOsFile osFile = null)
        {
            _dobihFile = dobihFile ?? new DobihFile();
            _osFile = osFile ?? new OsFile();

        }

        public DomainRoot Build()
        {
            var factory = new MountainFactory(_idGenerator);
            _domainRoot = new DomainRoot
            {
                Mountains = _dobihFile.Records
                .Select(MountainFactory.MountainFrom)
                .OrderByDescending(m => m.Height)
                .ToList();
        };

            return _domainRoot;
        }

        private List<Mountain> CreateMountains()
        {
            return 
        }

        private const int IdGeneratorSequenceSeed = 30000;
        private readonly IIdGenerator _idGenerator = new IdGenerator(IdGeneratorSequenceSeed);
        private readonly IDobihFile _dobihFile;
        private readonly IOsFile _osFile;
        private DomainRoot _domainRoot;
    }
}
