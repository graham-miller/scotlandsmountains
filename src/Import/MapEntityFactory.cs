using System.Collections.Generic;
using ScotlandsMountains.Domain;
using ScotlandsMountains.Import.OrdnanceSurvey;

namespace ScotlandsMountains.Import
{
    internal class MapEntityFactory
    {
        private readonly IMapReader _records;

        public IList<MapPublisher> MapPublishers { get; private set; }
        public IList<MapSeries> MapSeries { get; private set; }
        public IList<Map> Maps { get; private set; }

        public MapEntityFactory(IMapReader records)
        {
            _records = records;

            var publisher = new MapPublisher { Name = Constants.Name, MapSeries = new List<MapSeries>() };
            MapPublishers = new List<MapPublisher> { publisher };
            MapSeries = new List<MapSeries>();
            Maps = new List<Map>();

            CreateMapSeries(publisher, Constants.Explorer, 1 / 25000m, _records.ExplorerMaps);
            CreateMapSeries(publisher, Constants.ExplorerActive, 1 / 25000m, _records.ExplorerMapsActive);
            CreateMapSeries(publisher, Constants.Landranger, 1 / 50000m, _records.LandrangerMaps);
            CreateMapSeries(publisher, Constants.LandrangerActive, 1 / 50000m, _records.LandrangerMapsActive);
            CreateMapSeries(publisher, Constants.Discovery, 1 / 50000m, _records.IrishDiscoverMaps);
        }

        private void CreateMapSeries(MapPublisher publisher, string name, decimal scale, IEnumerable<Record> records)
        {
            var series = new MapSeries { Name = name };
            MapSeries.Add(series);
            publisher.MapSeries.Add(series);

            foreach (var record in records)
                Maps.Add(new Map
                    {
                        Publisher = publisher,
                        Series = series,
                        Sheet = record.Sheet,
                        Name = record.Name,
                        Scale = scale,
                        Isbn = record.Isbn,
                        PublicationDate = record.PublicationDate,
                        Edition = record.Edition,
                    });
        }
    }
}