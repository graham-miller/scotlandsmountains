using System;
using System.Collections.Generic;
using ScotlandsMountains.Domain.Entities;
using ScotlandsMountains.Domain.ValueTypes;
using System.Linq;

namespace ScotlandsMountains.Import.ConsoleApp.DatabaseOfBritishAndIrishHills.EntityFactories
{
    public class MountainsFactory
    {
        private readonly EntityFactory _entities;

        public MountainsFactory(IList<Record> records, EntityFactory entities)
        {
            _entities = entities;
            
            Mountains = new List<Mountain>();

            foreach (var record in records.OrderByDescending(r => decimal.Parse(r[Field.Metres])))
                AddNewMountainFrom(record);
        }

        public IList<Mountain> Mountains { get; }

        private void AddNewMountainFrom(Record record)
        {
            var mountain = new Mountain
            {
                DobihId = record[Field.Number],
                Name = record[Field.Name],
                Height = CreateHeight(record),
                Location = CreateLocation(record),
                Prominence = CreateProminence(record),
                SummitFeature = record[Field.Feature],
                SummitObservations = record[Field.Observations],
                SectionKey = GetSectionId(record),
                IslandKey = GetIslandId(record),
                CountyKeys = GetCountyIds(record),
                TopologicalSectionKey = GetTopologicalSectionId(record),
                MapKeys = GetMapIds(record),
                ClassificationKeys = GetClassificationIds(record)
            };

            Mountains.Add(mountain);
        }

        private static Height CreateHeight(Record record)
        {
            return new Height { Metres = double.Parse(record[Field.Metres]) };
        }

        private static Location CreateLocation(Record record)
        {
            var latitude = double.Parse(record[Field.Latitude]);
            var longitude = double.Parse(record[Field.Longitude]);
            var height = double.Parse(record[Field.Metres]);

            return new Location
            {
                Latitude = latitude,
                Longitude = longitude,
            };
        }

        private static Prominence CreateProminence(Record record)
        {
            return new Prominence
            {
                Metres = Math.Round(double.Parse(record[Field.Drop])),
                KeyCol = CreateKeyCol(record)
            };
        }

        private static KeyCol CreateKeyCol(Record record)
        {
            return new KeyCol
            {
                Location = record[Field.ColGridRef],
                Height = new Height {Metres = Math.Round(double.Parse(record[Field.ColHeight]))}
            };
        }

        private string GetSectionId(Record record)
        {
            return _entities.Sections.Single(x => x.Name == record[Field.SectionName].SectionName()).Key;
        }

        private string GetIslandId(Record record)
        {
            return _entities.Islands.SingleOrDefault(x => x.Name == record[Field.Island])?.Key;
        }

        private string[] GetCountyIds(Record record)
        {
            var county = record[Field.County].SplitCounties();
            return _entities.Counties.Where(x => county.Contains(x.Name)).Select(x => x.Key).ToArray();
        }

        private string GetTopologicalSectionId(Record record)
        {
            return _entities.TopologicalSections.Single(x => x.Name == record[Field.TopoSection].SectionName()).Key;
        }

        private string[] GetMapIds(Record record)
        {
            var maps = record[Field.Map1To25K].SplitMaps().Concat(record[Field.Map1To50K].SplitMaps());
            return _entities.Maps.Where(x => maps.Contains(x.Code)).Select(x => x.Key).ToArray();
        }

        private string[] GetClassificationIds(Record record)
        {
            var classifications = new List<string>();

            if (record[Field.Munro].IsTrue())
                classifications.Add(_entities.Classifications.Single(x => x.Name == Domain.Constants.Classifications.Munro).Key);

            if (record[Field.MunroTop].IsTrue())
                classifications.Add(_entities.Classifications.Single(x => x.Name == Domain.Constants.Classifications.MunroTop).Key);

            if (record[Field.Corbett].IsTrue())
                classifications.Add(_entities.Classifications.Single(x => x.Name == Domain.Constants.Classifications.Corbett).Key);

            if (record[Field.CorbettTop].IsTrue())
                classifications.Add(_entities.Classifications.Single(x => x.Name == Domain.Constants.Classifications.CorbettTop).Key);

            if (record[Field.Graham].IsTrue())
                classifications.Add(_entities.Classifications.Single(x => x.Name == Domain.Constants.Classifications.Graham).Key);

            if (record[Field.GrahamTop].IsTrue())
                classifications.Add(_entities.Classifications.Single(x => x.Name == Domain.Constants.Classifications.GrahamTop).Key);

            if (record[Field.Murdo].IsTrue())
                classifications.Add(_entities.Classifications.Single(x => x.Name == Domain.Constants.Classifications.Murdo).Key);

            if (record[Field.Donald].IsTrue())
                classifications.Add(_entities.Classifications.Single(x => x.Name == Domain.Constants.Classifications.Donald).Key);

            if (record[Field.DonaldDewey].IsTrue())
                classifications.Add(_entities.Classifications.Single(x => x.Name == Domain.Constants.Classifications.DonaldDewey).Key);

            if (record[Field.HighlandFive].IsTrue())
                classifications.Add(_entities.Classifications.Single(x => x.Name == Domain.Constants.Classifications.HighlandFive).Key);

            return classifications.ToArray();
        }
    }
}