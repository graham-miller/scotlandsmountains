using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ScotlandsMountains.Domain.Dobih.Csv
{
    public class ValidationResult
    {
        private readonly IList<string> _warnings;
        private readonly IList<string> _errors;

        public bool HasWarnings { get { return _warnings != null && _warnings.Any(); } }
        public ReadOnlyCollection<string> Warnings { get { return new ReadOnlyCollection<string>(_warnings); } }

        public bool HasErrors { get { return _errors != null && _errors.Any(); } }
        public ReadOnlyCollection<string> Errors { get { return new ReadOnlyCollection<string>(_errors); } }

        public ValidationResult()
        {
            _warnings = new List<string>();
            _errors = new List<string>();
        }

        public void AddWarning(string message)
        {
            _warnings.Add(message);
        }

        public void AddError(string message)
        {
            _errors.Add(message);
        }
    }
}