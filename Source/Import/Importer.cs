using System;
using System.Linq;
using ScotlandsMountains.Domain;

namespace ScotlandsMountains.Import
{
    public static class Importer
    {
        public static DomainRoot Import()
        {
            var osFile = new OsFile();
            //var dobihFile = new DobihFile();

            ////var classifications = dobi
            ////var sections 

            //var domainRoot = new DomainRoot
            //{
            //    Mountains = dobihFile.Records.Select(RecordTransformedToMountain).OrderByDescending(m => m.Height).ToList(),
            //};

            //dobihFile = null;

            //return domainRoot;
            return null;
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
