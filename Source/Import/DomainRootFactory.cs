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
            var maps = new MapsFactory(_idGenerator).BuildFrom(_osFile);
            var classifications = new ClassificationFactory(_idGenerator).BuildFrom(_dobihFile);
            var mountains = new MountainsFactory(_idGenerator).BuildFrom(_dobihFile);

            return new DomainRoot
            {
                Maps = maps,
                Classifications = classifications,
                Mountains = mountains
            };
        }

        private const int IdGeneratorSequenceSeed = 30000;

        private readonly IIdGenerator _idGenerator = new IdGenerator(IdGeneratorSequenceSeed);
        private readonly IDobihFile _dobihFile;
        private readonly IOsFile _osFile;
    }
}
