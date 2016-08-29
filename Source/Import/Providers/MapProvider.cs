using System.Linq;
using ScotlandsMountains.Domain;
using ScotlandsMountains.Import.Os;

namespace ScotlandsMountains.Import.Providers
{
    public interface IMapProvider
    {
        Maps GetAll();
    }

    public class MapProvider : IMapProvider
    {
        private readonly Maps _maps;

        public MapProvider(IIdGenerator idGenerator, IOsFile osFile)
        {
            _maps = LoadMaps(idGenerator, osFile);
        }

        public Maps GetAll()
        {
            return _maps;
        }

        private static Maps LoadMaps(IIdGenerator idGenerator, IOsFile osFile)
        {
            return new Maps
            {
                Landranger = osFile
                    .Landranger
                    .Select(x => Build(x, idGenerator.Generate(), MapConstants.Landranger, MapConstants.OneTo50K))
                    .ToList(),
                LandrangerActive = osFile
                    .LandrangerActive
                    .Select(x => Build(x, idGenerator.Generate(), MapConstants.LandrangerActive, MapConstants.OneTo50K))
                    .ToList(),
                Explorer = osFile
                    .Explorer
                    .Select(x => Build(x, idGenerator.Generate(), MapConstants.Explorer, MapConstants.OneTo25K))
                    .ToList(),
                ExplorerActive = osFile
                    .ExplorerActive
                    .Select(x => Build(x, idGenerator.Generate(), MapConstants.ExplorerActive, MapConstants.OneTo25K))
                    .ToList(),
                Discoverer = osFile
                    .Discoverer
                    .Select(x => Build(x, idGenerator.Generate(), MapConstants.Discoverer, MapConstants.OneTo50K))
                    .ToList(),
                Discovery = osFile
                    .Discovery
                    .Select(x => Build(x, idGenerator.Generate(), MapConstants.Discovery, MapConstants.OneTo50K))
                    .ToList()
            };
        }

        private static Map Build(OsRecord record, string id, string series, decimal scale)
        {
            return new Map
            {
                Id = id,
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
