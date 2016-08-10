using System;
using System.Linq;
using ScotlandsMountains.Domain;

namespace ScotlandsMountains.Import
{
    public static class Importer
    {
        public static DomainRoot Import()
        {
            var dobihFile = new DobihFile();

            var domainRoot = new DomainRoot
            {
                Mountains = dobihFile.Records.Select(RecordTransformedToMountain).ToList()
            };

            dobihFile = null;

            return domainRoot;
        }

        private static Mountain RecordTransformedToMountain(DobihRecord record)
        {
            return new Mountain
            {
                Id = IdGenerator.Instance.GenerateId(record.Number),
                Name = record.Name,
                Height = new Height
                {
                    Metres = record.Metres,
                    Feet = record.Feet
                },
                Location = new Location
                {
                    GridRef = new GridRef(record.GridRef),
                    Latitude = record.Latitude,
                    Longitude = record.Longitude
                }
            };
        }
    }
}
