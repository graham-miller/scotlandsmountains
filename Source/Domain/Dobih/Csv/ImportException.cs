using System;

namespace ScotlandsMountains.Domain.Dobih.Csv
{
    public class ImportException : Exception
    {
        public ImportException(string message) : base(message) { }
    }
}
