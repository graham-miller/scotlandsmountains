using System;
using System.Collections.Generic;
using System.Linq;

namespace ScotlandsMountains.Import.Dobih
{
    public interface IDobihRecord
    {
        int Number { get; }
        string Name { get; }
        string SectionName { get; }
        string SectionCode { get; }
        List<string> Classifications { get; }
        List<string> Maps1To50000 { get; }
        List<string> Maps1To25000 { get; }
        double Metres { get; }
        double Feet { get; }
        double Latitude { get; }
        double Longitude { get; }
        string GridRef { get; }
    }

    public class DobihRecord : IDobihRecord
    {
        private static class FieldNames
        {
            public const string Number = "Number";
            public const string Name = "Name";
            public const string SectionCode = "Section";
            public const string SectionName = "Section name";
            public const string Classification = "Classification";
            public const string Map1To50000 = "Map 1:50k";
            public const string Map1To25000 = "Map 1:25k";
            public const string Metres = "Metres";
            public const string Feet = "Feet";
            public const string Latitude = "Latitude";
            public const string Longitude = "Longitude";
            public const string GridRefXy = "GridrefXY";
            public const string GridRef = "Grid ref";
        }

        private static class Separators
        {
            public const string Space = " ";
            public const string Comma = ",";
            public const string Colon = ":";
        }

        public DobihRecord(string[] fields, IDictionary<string, int> columnIndexes)
        {
            _fields = fields;
            _columnIndexes = columnIndexes;
        }

        public int Number => GetInt(FieldNames.Number);

        public string Name => GetString(FieldNames.Name);

        public string SectionName => GetSectionName(FieldNames.SectionName);

        public string SectionCode => GetString(FieldNames.SectionCode);

        public List<string> Classifications => GetList(FieldNames.Classification, Separators.Comma);

        public List<string> Maps1To50000 => GetList(FieldNames.Map1To50000, Separators.Space);

        public List<string> Maps1To25000 => GetList(FieldNames.Map1To25000, Separators.Space);

        public double Metres => GetDouble(FieldNames.Metres);

        public double Feet => GetDouble(FieldNames.Feet);

        public double Latitude => GetDouble(FieldNames.Latitude);

        public double Longitude => GetDouble(FieldNames.Longitude);

        public string GridRef => GetGridRef();

        private string GetString(string fieldName)
        {
            return _fields[_columnIndexes[fieldName]];
        }

        private List<string> GetList(string fieldName, string separator)
        {
            return GetString(fieldName).Split(new [] { separator }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .ToList();
        }

        private double GetDouble(string fieldName)
        {
            return double.Parse(GetString(fieldName));
        }

        private int GetInt(string fieldName)
        {
            return int.Parse(GetString(fieldName));
        }

        private string GetSectionName(string fieldName)
        {
            var s = GetString(fieldName);
            return s.Substring(s.IndexOf(Separators.Colon) + 1).Trim();
        }

        private string GetGridRef()
        {
            var raw = GetString(FieldNames.GridRefXy);

            if (string.IsNullOrWhiteSpace(raw))
                raw = GetString(FieldNames.GridRef);

            return raw;
        }

        private readonly IDictionary<string, int> _columnIndexes;
        private readonly string[] _fields;
    }
}
