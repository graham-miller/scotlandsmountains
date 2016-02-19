using System;
using System.Collections.Generic;
using ScotlandsMountains.Domain.Entities;
using ScotlandsMountains.Domain.ValueTypes;
using System.Linq;

namespace ScotlandsMountains.ImportConsole.DatabaseOfBritishAndIrishHills.EntityFactories
{
    public class MountainsFactory
    {
        private IList<Map> _maps;

        public MountainsFactory(IList<Record> records, IList<Map> maps)
        {
            _maps = maps;
            
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
                SummitObservations = record[Field.Observations]
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
                KeyCol = new KeyCol
                {
                    Description = record[Field.ColGridRef],
                    Height = new Height {Metres = Math.Round(decimal.Parse(record[Field.ColHeight]))}
                }
            };
        }

        private int _id = 0;
    }
}