using ScotlandsMountains.Domain;
using ScotlandsMountains.Import.Dobih;
using ScotlandsMountains.Import.Providers;

namespace ScotlandsMountains.Import
{
    public class ImportParameters
    {
        public IDobihFile DobihFile { get; set; }
        public IIdGenerator IdGenerator { get; set; }
        public IEntityProvider<Country> CountryProvider { get; set; }
        public IEntityProvider<List> ListProvider { get; set; }
        public IEntityProvider<Section> SectionProvider { get; set; }
        public IMapProvider MapProvider { get; set; }
        public IEntityProvider<Mountain> MountainProvider => new MountainProvider(this);
    }
}