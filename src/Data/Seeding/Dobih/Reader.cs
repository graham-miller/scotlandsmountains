using System.Collections.Generic;
using System.IO;
using Microsoft.VisualBasic.FileIO;

namespace ScotlandsMountains.Data.Seeding.DatabaseOfBritishAndIrishHills
{
    internal class Reader
    {
        public Reader(string path)
        {
            var tfp = new TextFieldParser(path)
            {
                TextFieldType = FieldType.Delimited,
                Delimiters = new[] {","},
                HasFieldsEnclosedInQuotes = true
            };

            tfp.ReadLine(); // throw header row away

            var records = new List<Record>();

            while (!tfp.EndOfData)
                records.Add(new Record(tfp.ReadFields()));

            Records = records;
        }

        public IEnumerable<Record> Records { get; private set; }
    }
}
