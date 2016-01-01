using System;
using System.Globalization;
using System.Linq;

namespace ScotlandsMountains.Domain.Dobih.Csv
{
    public class Validation
    {
        public static ValidationResult ApplyTo(Reader reader)
        {
            var validation = new Validation(reader);
            return validation.Result;
        }

        private readonly Reader _reader;
        public ValidationResult Result { get; private set; }

        private Validation(Reader reader)
        {
            _reader = reader;
            Result = new ValidationResult();

            ValidateFileContainsData();
            ValidateHeaderRow();
        }

        private void ValidateFileContainsData()
        {
            if(!_reader.GetAllRows().Any())
                Result.AddError("The file contains no data.");
        }

        private void ValidateHeaderRow()
        {
            var headers = _reader.GetHeaderRow();

            var actualColumnCount = headers.Length;
            var expectedColumnCount = Enum.GetValues(typeof(Field)).Length;

            if (actualColumnCount != expectedColumnCount)
                Result.AddError(String.Format("The actual column count ({0}) does not match the expected column count ({1}).", actualColumnCount, expectedColumnCount));

            for (var i = 0; i < actualColumnCount; i++)
            {

                var actualColumnName = headers[i] ?? String.Empty;
                var expectedColumnName = ((Field)Enum.Parse(typeof(Field), i.ToString(CultureInfo.InvariantCulture))).Title();

                if (actualColumnName != expectedColumnName)
                    Result.AddError(String.Format("The column header at position {0} is \"{1}\" does not match the expected value (\"{2}\").", i + 1, actualColumnName, expectedColumnName));
            }
        }
    }
}
