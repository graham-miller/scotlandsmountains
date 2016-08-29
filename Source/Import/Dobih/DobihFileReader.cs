using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using Microsoft.VisualBasic.FileIO;
using ScotlandsMountains.Resources;

namespace ScotlandsMountains.Import.Dobih
{
    public interface IDobihFileReader
    {
        IDictionary<string, int> ColumnIndexes { get; }
        IList<string[]> Lines { get; }
    }

    public class DobihFileReader : IDobihFileReader
    {
        public IDictionary<string, int> ColumnIndexes { get; }
        public IList<string[]> Lines { get; } = new List<string[]>();

        public DobihFileReader()
        {
            using (var file = Load.Dobih.HillCsvZip)
            using (var zip = new ZipArchive(file, ZipArchiveMode.Read))
            using (var csv = zip.Entries[0].Open())
            using (var parser = new TextFieldParser(csv)
            {
                TextFieldType = FieldType.Delimited,
                Delimiters = new [] { "," },
                TrimWhiteSpace = true
            })
            {
                // ReSharper disable once AssignNullToNotNullAttribute
                ColumnIndexes = parser.ReadFields()
                    .Select((s, i) => new { Key = s, Value = i })
                    .ToDictionary(k => k.Key, v => v.Value);

                while (!parser.EndOfData)
                    Lines.Add(parser.ReadFields());
            }
        }
    }
}
