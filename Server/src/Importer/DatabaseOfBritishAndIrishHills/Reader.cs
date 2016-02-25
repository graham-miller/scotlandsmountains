using System;
using System.Collections.Generic;
using Microsoft.VisualBasic.FileIO;

namespace ScotlandsMountains.Importer.DatabaseOfBritishAndIrishHills
{
    public class Reader
    {
        public Reader(string path, Func<Record, bool> filter)
        {
            _path = path;
            _filter = filter;
        }

        public IList<Record> Read()
        {
            CreateConfiguredTextFieldParser();
            DiscardHeaderRow();
            return FilteredRecords();
        }

        private void CreateConfiguredTextFieldParser()
        {
            _parser = new TextFieldParser(_path)
            {
                TextFieldType = FieldType.Delimited,
                CommentTokens = new[] {"#"},
                Delimiters = new[] {","},
                HasFieldsEnclosedInQuotes = true
            };
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
                if (_filter(record))
                    records.Add(record);
            }
            return records;
        }

        private readonly string _path;
        private readonly Func<Record, bool> _filter;
        private TextFieldParser _parser;
    }
}
