using System.Collections.Generic;
using System.IO;

namespace ScotlandsMountains.Import.OrdnanceSurvey
{
    public class Reader : IMapReader
    {
        public Reader(
            string explorerMapsFilePath,
            string explorerMapsActiveFilePath,
            string landrangerMapsFilePath,
            string landrangerMapsActiveFilePath,
            string irishDiscoverMapsFilePath)
        {
            ExplorerMaps = Read(explorerMapsFilePath);
            ExplorerMapsActive = Read(explorerMapsActiveFilePath);
            LandrangerMaps = Read(landrangerMapsFilePath);
            LandrangerMapsActive = Read(landrangerMapsActiveFilePath);
            IrishDiscoverMaps = Read(irishDiscoverMapsFilePath);
        }

        public IList<Record> ExplorerMaps { get; set; }
        public IList<Record> ExplorerMapsActive { get; set; }
        public IList<Record> LandrangerMaps { get; set; }
        public IList<Record> LandrangerMapsActive { get; set; }
        public IList<Record> IrishDiscoverMaps { get; set; }

        private static IList<Record> Read(string filePath)
        {
            var records = new List<Record>();

            using (var reader = new StreamReader(filePath))
                while(!reader.EndOfStream)
                    records.Add(new Record(reader.ReadLine()));

            return records;
        }
    }
}
