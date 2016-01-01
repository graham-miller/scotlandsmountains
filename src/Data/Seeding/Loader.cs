using System.Collections.Generic;
using System.Linq;
using ScotlandsMountains.Data.Extensions;
using ScotlandsMountains.Data.Seeding.DatabaseOfBritishAndIrishHills;
using ScotlandsMountains.Data.Seeding.DatabaseOfBritishAndIrishHills.Factories;
using ScotlandsMountains.Data.Seeding.DatabaseOfBritishAndIrishHills.Wrappers;
using ScotlandsMountains.Domain.Entities;
using ScotlandsMountains.Domain.Entities.Maps;

namespace ScotlandsMountains.Data.Seeding
{
    public class Loader
    {
        public Loader(Configuration configuration)
        {
            _configuration = configuration;
        }

        public void Load(ScotlandsMountainsContext context)
        {
            _context = context;
            _context.Configuration.AutoDetectChangesEnabled = false;
            _context.Configuration.ValidateOnSaveEnabled = false;

            ClearDatabase();
            LoadDatabaseOfBritishAndIrishHillsData();
            LoadOrdnanceSurveyData();
            SaveEntitiesExceptMountains();
            CreateRelationships();
            SaveMountains();
            SaveMountainParents();
        }

        private void ClearDatabase()
        {
            _context.Database.ExecuteSqlCommand("DELETE FROM MountainCountries");
            _context.Database.ExecuteSqlCommand("DELETE FROM MountainClassifications");
            _context.Database.ExecuteSqlCommand("DELETE FROM MountainMaps");
            _context.Database.ExecuteSqlCommand("DELETE FROM Countries");
            _context.Database.ExecuteSqlCommand("DELETE FROM Classifications");
            _context.Database.ExecuteSqlCommand("DELETE FROM Maps");
            _context.Database.ExecuteSqlCommand("DELETE FROM Mountains");
            _context.Database.ExecuteSqlCommand("DELETE FROM Regions");
        }

        private void LoadDatabaseOfBritishAndIrishHillsData()
        {
            var loader = new DatabaseOfBritishAndIrishHills.Loader(_configuration.DobihCsvPath.FullyQualified);
            loader.Load();
            _records = loader.Records.OrderByDescending(x => x.Metres).ToList();
            _regions = loader.Regions.OrderBy(x => x.Name).ToList();
        }

        private void LoadOrdnanceSurveyData()
        {
            var configuration = GetOrdnanceSurveyLoaderConfiguration();
            var loader = new OrdnanceSurvey.Loader(configuration);
            loader.Load();
            _maps = loader.Maps;
        }

        private OrdnanceSurvey.Loader.Configuration GetOrdnanceSurveyLoaderConfiguration()
        {
            return new OrdnanceSurvey.Loader.Configuration
                {
                    OsExplorerTxtPath = _configuration.OsExplorerTxtPath.FullyQualified,
                    OsExplorerActiveTxtPath = _configuration.OsExplorerActiveTxtPath.FullyQualified,
                    OsLandrangerTxtPath = _configuration.OsLandrangerTxtPath.FullyQualified,
                    OsLandrangerActiveTxtPath = _configuration.OsLandrangerActiveTxtPath.FullyQualified,
                    OsDiscoveryTxtPath = _configuration.OsDiscoveryTxtPath.FullyQualified
                };
        }

        private void SaveEntitiesExceptMountains()
        {
            _classifications.ForEach(x => _context.Classifications.Add(x.Classification));
            _regions.ForEach(x => _context.Regions.Add(x));
            _countries.ForEach(x => _context.Countries.Add(x.Country));
            _maps.ForEach(x => _context.Maps.Add(x));

            _context.SaveChanges();
        }

        private void CreateRelationships()
        {
            foreach (var record in _records)
            {
                record.Mountain.Classifications = _classifications.Where(x => x.IsMember(record)).Select(x => x.Classification).ToList();
                record.Mountain.Countries = _countries.Where(x => record.Country.Contains(x.Code)).Select(x => x.Country).ToList();
                record.Mountain.Region = _regions.Single(x => x.Name == record.Region);
                MapMapsTo(record);
            }
        }

        private void SaveMountains()
        {
            foreach (var partition in _records.Partition(1000))
            {
                partition.ToList().ForEach(x => _context.Mountains.Add(x.Mountain));
                _context.SaveChanges();
            }
        }

        private void SaveMountainParents()
        {
            _context.Configuration.AutoDetectChangesEnabled = true;

            foreach (var partition in _records.Where(x => x.ParentNumber.HasValue).Partition(1000))
            {
                foreach (var record in partition)
                {
                    var parent = _records.SingleOrDefault(x => x.Number == record.ParentNumber);
                    if (parent != null)
                        record.Mountain.Parent = parent.Mountain;
                }
                _context.SaveChanges();
            }

            _context.Configuration.AutoDetectChangesEnabled = false;
        }

        private void MapMapsTo(Record record)
        {
            if (record.IsIrish())
            {
                MapMapsTo<OsDiscoveryMap>(record, record.Map1To50000, MapScale.OneTo50000);
            }
            else
            {
                MapMapsTo<OsExplorerMap>(record, record.Map1To25000, MapScale.OneTo25000);
                MapMapsTo<OsExplorerActiveMap>(record, record.Map1To25000, MapScale.OneTo25000);
                MapMapsTo<OsLandrangerMap>(record, record.Map1To50000, MapScale.OneTo50000);
                MapMapsTo<OsLandrangerActiveMap>(record, record.Map1To50000, MapScale.OneTo50000);
            }
        }

        private void MapMapsTo<T>(Record record, IEnumerable<string> mapCodes, decimal scale) where T : Map, new()
        {
            _maps
                .OfType<T>()
                .Where(map => map.Scale == scale && mapCodes.Contains(map.Code))
                .ToList()
                .ForEach(map => record.Mountain.Maps.Add(map));
        }

        private readonly Configuration _configuration;
        private ScotlandsMountainsContext _context;
        private List<Record> _records;
        private List<Region> _regions;
        private List<Map> _maps;
        private readonly List<CountryWrapper> _countries = CountriesFactory.Build();
        private readonly List<ClassificationWrapper> _classifications = ClassificationFactory.Build();

        public class Configuration
        {
            public ImportPath DobihCsvPath { get; set; }
            public ImportPath OsExplorerTxtPath { get; set; }
            public ImportPath OsExplorerActiveTxtPath { get; set; }
            public ImportPath OsLandrangerTxtPath { get; set; }
            public ImportPath OsLandrangerActiveTxtPath { get; set; }
            public ImportPath OsDiscoveryTxtPath { get; set; }
        }
    }
}
