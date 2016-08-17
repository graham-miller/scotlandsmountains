using ScotlandsMountains.Domain;
using ScotlandsMountains.Import.Dobih;
using ScotlandsMountains.Import.Os;

namespace ScotlandsMountains.Import
{
    public static class Importer
    {
        public static DomainRoot Import(IOsFileReader osFileReader = null, IOsFileParser osFileParser = null, bool debug = false)
        {
            osFileReader = osFileReader ?? new OsFileReader();
            osFileParser = osFileParser ?? new OsFileParser();

            var osFile = new OsFile(osFileReader, osFileParser, debug);

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
