using System.Linq;
using ScotlandsMountains.Domain;
using ScotlandsMountains.Import.Os;

namespace ScotlandsMountains.Import
{
    public class MapsFactory
    {
        private readonly IIdGenerator _idGenerator;

        public MapsFactory(IIdGenerator idGenerator)
        {
            _idGenerator = idGenerator;
        }

        public Maps BuildFrom(IOsFile file)
        {
            return new Maps
            {
                Landranger = file
                    .LandrangerMaps
                    .Select(x => Build(x, MapConstants.Landranger, MapConstants.OneTo50K))
                    .ToList(),
                LandrangerActive = file
                    .LandrangerActiveMaps
                    .Select(x => Build(x, MapConstants.LandrangerActive, MapConstants.OneTo50K))
                    .ToList(),
                Explorer = file
                    .ExplorerMaps
                    .Select(x => Build(x, MapConstants.Explorer, MapConstants.OneTo25K))
                    .ToList(),
                ExplorerActive = file
                    .ExplorerActiveMaps
                    .Select(x => Build(x, MapConstants.ExplorerActive, MapConstants.OneTo25K))
                    .ToList(),
                Discoverer = file
                    .DiscovererMaps
                    .Select(x => Build(x, MapConstants.Discoverer, MapConstants.OneTo50K))
                    .ToList(),
                Discovery = file
                    .DiscoveryMaps
                    .Select(x => Build(x, MapConstants.Discovery, MapConstants.OneTo50K))
                    .ToList()
            };
        }

        private Map Build(OsRecord record, string series, decimal scale)
        {
            return new Map
            {
                Id = _idGenerator.Generate(),
                Publisher = MapConstants.OrdnanceSurvey,
                Series = series,
                Code = record.Code,
                Name = record.Name,
                Isbn = record.Isbn,
                Scale = scale
            };
        }
    }
}