namespace ScotlandsMountains.ImportConsole.Dobih
{
    public class Record
    {
        private readonly string[] _fields;

        public Record(string[] fields)
        {
            _fields = fields;
        }

        public string this[Field.Definition fieldDefinition]
        {
            get { return _fields[fieldDefinition.Index].Trim(); }
        }
    }
}
