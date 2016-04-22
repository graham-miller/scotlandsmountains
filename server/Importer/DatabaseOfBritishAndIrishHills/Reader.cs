using System.Collections.Generic;
using Microsoft.VisualBasic.FileIO;

namespace ScotlandsMountains.Importer.DatabaseOfBritishAndIrishHills
{
    public class Reader
    {
        public IList<Record> Read()
        {
            using (var stream = Resources.Get.DobihCsv)
            using (_parser = new TextFieldParser(stream))
            {
                _parser.TextFieldType = FieldType.Delimited;
                _parser.CommentTokens = new[] { "#" };
                _parser.Delimiters = new[] { "," };
                _parser.HasFieldsEnclosedInQuotes = true;

                DiscardHeaderRow();
                return FilteredRecords();
            }
        }

        private void DiscardHeaderRow()
        {
            _parser.ReadLine();
        }

        private IList<Record> FilteredRecords()
        {
            var records = new List<Record>();
            while (!_parser.EndOfData)
            {
                var record = new Record(_parser.ReadFields());
                if (ShouldInclude(record))
                    records.Add(record);
            }
            return records;
        }

        private static bool ShouldInclude(Record record)
        {
            return record[Field.Country] == "S" || record[Field.Country] == "ES";
        }

        private TextFieldParser _parser;
    }
}
