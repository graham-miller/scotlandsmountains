using System.Collections.Generic;
using System.IO.Compression;
using Microsoft.VisualBasic.FileIO;
using ScotlandsMountains.Resources;
using System.Linq;

namespace ScotlandsMountains.Import
{
    internal class DobihFile
    {
        public DobihFile()
        {
            using (var file = Load.Dobih.HillCsvZip())
            using (var zip = new ZipArchive(file, ZipArchiveMode.Read))
            using (var csv = zip.Entries[0].Open())
            using (var parser = new TextFieldParser(csv)
            {
                TextFieldType = FieldType.Delimited,
                Delimiters = new string[] { "," },
                TrimWhiteSpace = true
            })
            {
                ColumnIndex = parser.ReadFields()
                    .Select((s,i) => new {Key = s, Value = i})
                    .ToDictionary(k => k.Key, v => v.Value);

                while (!parser.EndOfData)
                    _records.Add(new DobihRecord(parser.ReadFields(), this));
            }
        }

        public IDictionary<string,int> ColumnIndex { get; private set; } 
        private IList<DobihRecord> _records = new List<DobihRecord>();
    }
}
