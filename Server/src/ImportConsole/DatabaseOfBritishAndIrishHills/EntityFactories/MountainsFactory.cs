using System;
using System.Collections.Generic;
using ScotlandsMountains.Domain.Entities;
using ScotlandsMountains.Domain.ValueTypes;
using System.Linq;

namespace ScotlandsMountains.ImportConsole.DatabaseOfBritishAndIrishHills.EntityFactories
{
    public class MountainsFactory
    {
        private IList<Record> _records;
        private IList<Map> _maps;

        public MountainsFactory(IList<Record> records, IList<Map> maps)
        {
            _records = records;
            _maps = maps;
            
            Mountains = new List<Mountain>();

            foreach (var record in records.OrderByDescending(r => decimal.Parse(r[Field.Metres])))
                AddNewMountainFrom(record);
        }

        public IList<Mountain> Mountains { get; private set; }

        private void AddNewMountainFrom(Record record)
        {
            var mountain = new Mountain
            {
                Id = ++_id,
                DobihId = record[Field.Number],
                Name = record[Field.Name],
                Height = CreateHeight(record),
                Location = CreateLocation(record)
            };

            Mountains.Add(mountain);
        }

        private Height CreateHeight(Record record)
        {
            return new Height { Metres = decimal.Parse(record[Field.Metres]) };
        }

        private Location CreateLocation(Record record)
        {
            return new Location
            {
                Latitude = double.Parse(record[Field.Latitude]),
                Longitude = double.Parse(record[Field.Longitude])
            };
        }

        private int _id = 0;
    }
}