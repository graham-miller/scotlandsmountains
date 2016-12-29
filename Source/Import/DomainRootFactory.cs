using ScotlandsMountains.Domain;

namespace ScotlandsMountains.Import
{
    public class DomainRootFactory
    {
        public DomainRootFactory(ImportParameters importParameters)
        {
            _importParameters = importParameters;
        }

        public DomainRoot Build()
        {
            var domainRoot = new DomainRoot
            {
                Maps = _importParameters.MapProvider.GetAll(),
                Lists = _importParameters.ListProvider.GetAll(),
                Sections = _importParameters.SectionProvider.GetAll(),
                Countries = _importParameters.CountryProvider.GetAll(),
                Mountains = _importParameters.MountainProvider.GetAll()
            };

            return domainRoot;
        }

        private readonly ImportParameters _importParameters;
    }
}
