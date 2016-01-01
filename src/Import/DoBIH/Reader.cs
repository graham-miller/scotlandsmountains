using System.Collections.Generic;
using Microsoft.VisualBasic.FileIO;

namespace ScotlandsMountains.Import.Dobih
{
    internal class Reader : IDobihReader
    {
        public IList<Record> Records { get; private set; }

        public Reader(string filePath)
        {
            Records = new List<Record>();

            using (var reader = new TextFieldParser(filePath))
            {
                reader.TextFieldType = FieldType.Delimited;
                reader.SetDelimiters(new[] { "," });
                reader.HasFieldsEnclosedInQuotes = true;

                reader.ReadLine(); // skip header row

                while (!reader.EndOfData)
                    Records.Add(new Record(reader.ReadFields()));
            }
        }
    }
}
