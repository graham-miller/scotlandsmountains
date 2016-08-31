using System.Collections.Generic;
using System.Linq;
using ScotlandsMountains.Domain;
using ScotlandsMountains.Import.Os;

namespace ScotlandsMountains.Import.Providers
{
    public interface IMapProvider
    {
        Maps GetAll();
        IList<Map> GetMapsByCode(decimal scale, MapConstants.Region region, IList<string> codes);
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

        public IList<Map> GetMapsByCode(decimal scale, MapConstants.Region region, IList<string> codes)
        {
            if (region == MapConstants.Region.Ireland)
            {
                if (scale == MapConstants.OneTo50K)
                {
                    return
                        _maps.Discoverer.Where(x => codes.Contains(x.Code))
                            .Concat(_maps.Discovery.Where(x => codes.Contains(x.Code)))
                            .ToList();
                }
            }

            if (region == MapConstants.Region.GreatBritain)
            {
                if (scale == MapConstants.OneTo50K)
                {
                    return
                        _maps.Landranger.Where(x => codes.Contains(x.Code))
                            .Concat(_maps.LandrangerActive.Where(x => codes.Contains(x.Code)))
                            .ToList();
                }
                if (scale == MapConstants.OneTo25K)
                {
                    return
                        _maps.Explorer.Where(x => codes.Contains(x.Code))
                            .Concat(_maps.ExplorerActive.Where(x => codes.Contains(x.Code)))
                            .ToList();
                }
            }

            return new List<Map>();
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
