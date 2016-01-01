using System.Collections.Generic;
using ScotlandsMountains.Domain;

namespace ScotlandsMountains.Import
{
    internal class EntityFactory
    {
        private readonly ClassificationEntityFactory _classificationEntityFactory;
        private readonly MapEntityFactory _mapEntityFactory;
        private readonly AreaEntityFactory _areaEntityFactory;
        private readonly CountryEntityFactory _countryEntityFactory;
        private readonly MountainEntityFactory _mountainEntityFactory;

        public IList<Classification> Classifications { get { return _classificationEntityFactory.Classifications; } }
        public IList<Country> Countries { get { return _countryEntityFactory.Countries; } }
        public IList<Area> Areas { get { return _areaEntityFactory.Areas; } }
        public IList<MapPublisher> MapPublishers { get { return _mapEntityFactory.MapPublishers; } }
        public IList<MapSeries> MapSeries { get { return _mapEntityFactory.MapSeries; } }
        public IList<Map> Maps { get { return _mapEntityFactory.Maps; } }
        public IList<Mountain> Mountains { get { return _mountainEntityFactory.Mountains; } }

        public EntityFactory(IDobihReader mountainRecords, IMapReader mapRecords)
        {
            _classificationEntityFactory = new ClassificationEntityFactory();
            _mapEntityFactory = new MapEntityFactory(mapRecords);
            _areaEntityFactory = new AreaEntityFactory(mountainRecords);
            _countryEntityFactory = new CountryEntityFactory();
            
            _mountainEntityFactory = new MountainEntityFactory(
                mountainRecords,
                _countryEntityFactory,
                _areaEntityFactory,
                _mapEntityFactory,
                _classificationEntityFactory);
        }
    }
}
