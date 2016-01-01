using System.Collections.Generic;
using System.IO;
using System.Linq;
using ScotlandsMountains.Domain.Entities;

namespace ScotlandsMountains.Data.Seeding.DatabaseOfBritishAndIrishHills
{
    internal class Loader
    {
        public List<Record> Records { get; private set; }
        public List<Region> Regions { get; private set; }

        public Loader(string csvPath)
        {
            _csvPath = csvPath;
        }

        public void Load()
        {
            LoadRecords();
            LoadRegions();
        }

        private void LoadRecords()
        {
            Records = new Reader(_csvPath).Records.ToList();            
        }

        private void LoadRegions()
        {
            Regions = Records.Select(x => x.Region).Distinct().Select(x => new Region(x)).ToList();
        }

        private readonly string _csvPath;
    }
}
