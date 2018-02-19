using System.Collections.Generic;
using System.IO;
using Microsoft.VisualBasic.FileIO;
using ScotlandsMountains.Domain;
using ScotlandsMountains.Resources;

namespace ScotlandsMountains.Import
{
    internal static class HillCsvParser
    {
        public static IList<DobihRecord> Parse()
        {
            var records = new List<string[]>();

            using (var stream = File.OpenRead(FileHelper.HillCsvPath))
            using (var textFieldParser = new TextFieldParser(stream)
            {
                TextFieldType = FieldType.Delimited,
                Delimiters = new[] { "," },
                TrimWhiteSpace = true
            })
            {
                string[] header = null;
                if (!textFieldParser.EndOfData)
                    header = textFieldParser.ReadFields();

                while (!textFieldParser.EndOfData)
                    records.Add(textFieldParser.ReadFields());

                return DobihRecord.BuildFrom(header, records);
            }
        }
    }
}
