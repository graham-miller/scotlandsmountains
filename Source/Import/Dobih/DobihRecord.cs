using System;
using System.Collections.Generic;
using System.Linq;
using ScotlandsMountains.Domain;

namespace ScotlandsMountains.Import.Dobih
{
    public interface IDobihRecord
    {
        int Number { get; }
        string Name { get; }
        string SectionName { get; }
        string SectionCode { get; }
        List<string> Lists { get; }
        List<string> Maps1To50000 { get; }
        List<string> Maps1To25000 { get; }
        double Metres { get; }
        double Feet { get; }
        double Latitude { get; }
        double Longitude { get; }
        string GridRef { get; }
        double Drop { get; }
        string ColGridRef { get; }
        double ColMetres { get; }
        string Feature { get; }
        string Observations { get; }
        string Country { get; }
        bool IsIrish();
    }

    public class DobihRecord : IDobihRecord
    {
        private static class FieldNames
        {
            public const string Number = "Number";
            public const string Name = "Name";
            public const string SectionCode = "Section";
            public const string SectionName = "Section name";
            public const string List = "Classification";
            public const string Map1To50000 = "Map 1:50k";
            public const string Map1To25000 = "Map 1:25k";
            public const string Metres = "Metres";
            public const string Feet = "Feet";
            public const string Drop = "Drop";
            public const string ColGridRef = "Col grid ref";
            public const string ColHeight = "Col height";
            public const string Feature = "Feature";
            public const string Observations = "Observations";
            public const string Country = "Country";
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

        public List<string> Lists => GetList(FieldNames.List, Separators.Comma);

        public List<string> Maps1To50000 => GetList(FieldNames.Map1To50000, Separators.Space);

        public List<string> Maps1To25000 => GetList(FieldNames.Map1To25000, Separators.Space);

        public double Metres => GetDouble(FieldNames.Metres);

        public double Feet => GetDouble(FieldNames.Feet);

        public double Latitude => GetDouble(FieldNames.Latitude);

        public double Longitude => GetDouble(FieldNames.Longitude);

        public string GridRef => GetGridRef();

        public double Drop => GetDouble(FieldNames.Drop);

        public string ColGridRef => GetColGridRef();

        public double ColMetres => GetDouble(FieldNames.ColHeight);

        public string Feature => GetString(FieldNames.Feature);

        public string Observations => GetString(FieldNames.Observations);

        public string Country => GetString(FieldNames.Country);

        public bool IsIrish()
        {
            return Country == Ireland;
        }

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
            return s.Substring(s.IndexOf(Separators.Colon, StringComparison.Ordinal) + 1).Trim();
        }

        private string GetGridRef()
        {
            var raw = GetString(FieldNames.GridRefXy);

            if (string.IsNullOrWhiteSpace(raw))
                raw = GetString(FieldNames.GridRef);

            return raw;
        }

        private string GetColGridRef()
        {
            var raw = GetString(FieldNames.ColGridRef);

            if (Domain.GridRef.IsValid(raw))
                return new GridRef(raw).TenFigure;

            return raw;
        }

        private readonly IDictionary<string, int> _columnIndexes;
        private readonly string[] _fields;

        private const string Ireland = "I";
    }
}
