using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using ScotlandsMountains.Domain.Entities;
using ScotlandsMountains.Domain.ValueTypes;

namespace ScotlandsMountains.Domain.Dobih.Csv
{
    public class Importer
    {
        private const string MapPublisher = "Ordnance Survey";
        private const decimal ExplorerScale = 0.00004m;
        private const decimal LandrangerScale = 0.00002m;

        private readonly Reader _reader;
        private IEnumerable<string[]> _records;            

        public IList<Mountain> Mountains { get; private set; }
        public IList<Map> Maps { get; private set; }
        public IList<Area> Areas { get; private set; }
        public IList<Table> Tables { get; private set; }

        public Importer(string pathToCsv)
        {
            _reader = new Reader(pathToCsv);
            ValidateFile();
            ImportData();
        }

        private void ValidateFile()
        {
            var validationResult = Validation.ApplyTo(_reader);
            if (validationResult.HasErrors)
                throw new ImportException(
                    String.Format(
                        "The file could not be loaded because:{0}{1}",
                        Environment.NewLine,
                        String.Join(Environment.NewLine, validationResult.Errors)
                    ));
        }

        private void ImportData()
        {
            _records = _reader.GetDataRows().Where(ShouldBeIncluded);
            GetTables();
            GetAreas();
            GetMaps();
            GetMountains();
            MapMountainsToTables();
        }

        private void GetAreas()
        {
            Areas =
                _records
                    .Select(x => x[(int)Field.Region])
                    .Distinct()
                    .OrderBy(x => x)
                    .Select(x => new Area { Name = x})
                    .ToList();
        }

        private void GetMountains()
        {
            var ordered = _records.OrderByDescending(x => x[(int)Field.Feet]).ToList();

            Mountains = new List<Mountain>();

            foreach(var record in ordered)
                Mountains.Add(MapToMountain(record));
        }

        private void GetMaps()
        {
            var landrangerCodes = new List<int>();
            var explorerCodes = new List<int>();

            foreach (var record in _records)
            {
                landrangerCodes.AddRange(ExtractMapCodesFrom(record, Field.Map));
                explorerCodes.AddRange(ExtractMapCodesFrom(record, Field.Map25));
            }

            Maps = landrangerCodes
                .Distinct()
                .OrderBy(x => x)
                .Select(x => new Map(MapPublisher, LandrangerScale, x))
                .Union(
                    explorerCodes
                        .Distinct()
                        .OrderBy(x => x)
                        .Select(x => new Map(MapPublisher, ExplorerScale, x))
                )
                .ToList();
        }

        private IEnumerable<int> ExtractMapCodesFrom(IList<string> record, Field field)
        {
            return record[(int)field]
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => Int32.Parse(Regex.Replace(x, @"[\D]", "")))
                .ToList();
        }

        private Mountain MapToMountain(string[] record)
        {
            return new Mountain
            {
                Name = GetNameFrom(record),
                Height = GetHeightFrom(record),
                Location = GetLocationFrom(record),
                Summit = GetSummitFrom(record),
                Maps = GetMapsFrom(record),
                DobihId = GetDobihIdFrom(record),
                Parent = GetParentFrom(record),
                Tables = GetTablesFrom(record)
            };
        }

        private void GetTables()
        {
            Tables = new List<Table>
                {
                    new Table {Name = "Munro"},
                    new Table {Name = "Corbett"},
                    new Table {Name = "Graham"},
                    new Table {Name = "Donald"},
                    new Table {Name = "Munro top"},
                    new Table {Name = "Corbett top"},
                    new Table {Name = "Graham top"},
                    new Table {Name = "Donald top"},
                    new Table {Name = "Murdo"}
                };
        }

        private static bool ShouldBeIncluded(string[] record)
        {
            return
                record[(int)Field.Munro] == "1" ||
                record[(int)Field.Corbett] == "1" ||
                record[(int)Field.Graham] == "1" ||
                record[(int)Field.Donald] == "1" ||
                record[(int)Field.MunroTop] == "1" ||
                record[(int)Field.CorbettTop] == "1" ||
                record[(int)Field.GrahamTop] == "1" ||
                record[(int)Field.DonaldTop] == "1" ||
                record[(int)Field.Murdo] == "1";
        }

        private IList<Table> GetTablesFrom(string[] record)
        {
            var tables = new List<Table>();

            if (record[(int) Field.Munro] == "1")
                tables.Add(Tables[0]);

            if(record[(int)Field.Corbett] == "1")
                tables.Add(Tables[1]);

            if (record[(int)Field.Graham] == "1")
                tables.Add(Tables[2]);

            if (record[(int)Field.Donald] == "1")
                tables.Add(Tables[3]);

            if (record[(int)Field.MunroTop] == "1")
                tables.Add(Tables[4]);

            if (record[(int)Field.CorbettTop] == "1")
                tables.Add(Tables[5]);

            if (record[(int)Field.GrahamTop] == "1")
                tables.Add(Tables[6]);

            if (record[(int)Field.DonaldTop] == "1")
                tables.Add(Tables[7]);

            if (record[(int)Field.Murdo] == "1")
                tables.Add(Tables[8]);

            return tables;
        }

        private void MapMountainsToTables()
        {
            foreach (var mountain in Mountains)
                foreach (var table in mountain.Tables)
                    if(!table.Mountains.Contains(mountain))
                        table.Mountains.Add(mountain);
        }

        private Mountain GetParentFrom(string[] record)
        {
            if (String.IsNullOrEmpty(record[(int) Field.ParentNumber])) return null;
            return Mountains.FirstOrDefault(x => x.DobihId == Int32.Parse(record[(int) Field.ParentNumber]));
        }

        private int GetDobihIdFrom(string[] record)
        {
            return Int32.Parse(record[(int)Field.Number]);
        }

        private static string GetNameFrom(IList<string> record)
        {
            return record[(int)Field.Name];
        }

        private static Height GetHeightFrom(IList<string> record)
        {
            return new Height(Decimal.Parse(record[(int)Field.Feet]));
        }

        private Location GetLocationFrom(IList<string> record)
        {
            return new Location(
                record[(int)Field.GridRefXy],
                Double.Parse(record[(int)Field.Latitude]),
                Double.Parse(record[(int)Field.Longitude]),
                Areas.FirstOrDefault(x => x.Name == record[(int)Field.Region]));
        }

        private static Summit GetSummitFrom(IList<string> record)
        {
            return new Summit
            {
                Feature = record[(int)Field.Feature],
                Observations = record[(int)Field.Observations]
            };
        }

        private IList<Map> GetMapsFrom(IList<string> record)
        {
            var landrangerCodes = ExtractMapCodesFrom(record, Field.Map);
            var explorerCodes = ExtractMapCodesFrom(record, Field.Map25);

            return Maps
                .Where(x => x.Scale == LandrangerScale && landrangerCodes.Contains(x.Code))
                .Union(
                    Maps.Where(x => x.Scale == ExplorerScale && explorerCodes.Contains(x.Code))
                ).ToList();
        }
    }
}
