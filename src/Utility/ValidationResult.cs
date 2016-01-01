namespace ScotlandsMountains.Utility
{
    public class ValidationResult
    {
        public enum SeverityLevel
        {
            Warning,
            Error
        }

        public ValidationResult(string message, SeverityLevel severity = SeverityLevel.Error)
        {
            Severity = severity;
            Message = message;
        }

        public string Message { get; private set; }
        public SeverityLevel Severity { get; private set; }
    }
}
