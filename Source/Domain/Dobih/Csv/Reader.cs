using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualBasic.FileIO;

namespace ScotlandsMountains.Domain.Dobih.Csv
{
    public class Reader
    {
        private readonly string _pathToCsv;

        public Reader(string pathToCsv)
        {
            _pathToCsv = pathToCsv;
        }

        public string[] GetHeaderRow()
        {
            return GetAllRows().FirstOrDefault();
        }

        public IEnumerable<string[]> GetDataRows()
        {
            return GetAllRows().Skip(1);
        }

        public IEnumerable<string[]> GetAllRows()
        {
            using (var reader = OpenFile())
            {
                while (!reader.EndOfData)
                {
                    yield return reader.ReadFields();
                }
            }
        }

        private TextFieldParser OpenFile()
        {
            var reader = new TextFieldParser(_pathToCsv) {TextFieldType = FieldType.Delimited};
            reader.SetDelimiters(",");
            return reader;
        }
    }
}
