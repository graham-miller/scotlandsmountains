using System;
using System.Collections.Generic;
using ScotlandsMountains.Domain.Entities;
using ScotlandsMountains.Domain.ValueTypes;
using System.Linq;

namespace ScotlandsMountains.ImportConsole.DatabaseOfBritishAndIrishHills.EntityFactories
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
                Id = ++_id,
                DobihId = record[Field.Number],
                Name = record[Field.Name],
                Height = CreateHeight(record),
                Location = CreateLocation(record),
                Prominence = CreateProminence(record),
                SummitFeature = record[Field.Feature],
                SummitObservations = record[Field.Observations],
                SectionId = GetSectionId(record),
                IslandId = GetIslandId(record),
                CountyIds = GetCountyIds(record),
                TopologicalSectionId = GetTopologicalSectionId(record),
                MapIds = GetMapIds(record)
            };


            Mountains.Add(mountain);
        }

        private static Height CreateHeight(Record record)
        {
            return new Height { Metres = decimal.Parse(record[Field.Metres]) };
        }

        private static Location CreateLocation(Record record)
        {
            return new Location
            {
                Latitude = double.Parse(record[Field.Latitude]),
                Longitude = double.Parse(record[Field.Longitude])
            };
        }

        private static Prominence CreateProminence(Record record)
        {
            return new Prominence
            {
                Metres = Math.Round(decimal.Parse(record[Field.Drop])),
                KeyCol = CreateKeyCol(record)
            };
        }

        private static KeyCol CreateKeyCol(Record record)
        {
            return new KeyCol
            {
                Description = record[Field.ColGridRef],
                Height = new Height {Metres = Math.Round(decimal.Parse(record[Field.ColHeight]))}
            };
        }

        private int GetSectionId(Record record)
        {
            return _entities.Sections.Single(x => x.Name == record[Field.SectionName].SectionName()).Id;
        }

        private int? GetIslandId(Record record)
        {
            return _entities.Islands.SingleOrDefault(x => x.Name == record[Field.Island])?.Id;
        }

        private int[] GetCountyIds(Record record)
        {
            var county = record[Field.County].SplitCounties();
            return _entities.Counties.Where(x => county.Contains(x.Name)).Select(x => x.Id).ToArray();
        }

        private int GetTopologicalSectionId(Record record)
        {
            return _entities.TopologicalSections.Single(x => x.Name == record[Field.TopoSection].SectionName()).Id;
        }

        private int[] GetMapIds(Record record)
        {
            var maps = record[Field.Map1To25K].SplitMaps().Concat(record[Field.Map1To50K].SplitMaps());
            return _entities.Maps.Where(x => maps.Contains(x.Name)).Select(x => x.Id).ToArray();
        }

        private int _id = 0;
    }
}