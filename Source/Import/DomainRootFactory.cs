using ScotlandsMountains.Domain;
using ScotlandsMountains.Import.Dobih;
using ScotlandsMountains.Import.Os;
using ScotlandsMountains.Import.ScotlandsMountains;

namespace ScotlandsMountains.Import
{
    public class DomainRootFactory
    {
        public DomainRootFactory(IDobihFile dobihFile = null, IOsFile osFile = null, IClassificationInfoProvider classificationInfoProvider = null)
        {
            _dobihFile = dobihFile ?? new DobihFile();
            _osFile = osFile ?? new OsFile();
            _classificationInfoProvider = classificationInfoProvider ?? new ClassificationInfoProvider();
        }

        public DomainRoot Build()
        {
            var domainRoot = new DomainRoot
            {
                Maps = new MapsFactory(_idGenerator).BuildFrom(_osFile),
                Classifications = new ClassificationFactory(_idGenerator, _classificationInfoProvider).BuildFrom(_dobihFile),
                Sections = new SectionFactory(_idGenerator).BuildFrom(_dobihFile),
                Countries = new CountryFactory(_idGenerator).BuildFrom(_dobihFile)
            };

            domainRoot.Mountains = new MountainsFactory(_idGenerator, domainRoot).BuildFrom(_dobihFile);

            return domainRoot;
        }

        private const int IdGeneratorSequenceSeed = 30000; // IDs below 30,000 are reserved for mountains

        private readonly IIdGenerator _idGenerator = new IdGenerator(IdGeneratorSequenceSeed);
        private readonly IDobihFile _dobihFile;
        private readonly IOsFile _osFile;
        private readonly IClassificationInfoProvider _classificationInfoProvider;
    }
}
