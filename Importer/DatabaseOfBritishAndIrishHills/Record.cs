namespace ScotlandsMountains.Importer.DatabaseOfBritishAndIrishHills
{
    public class Record
    {
        private readonly string[] _fields;

        public Record(string[] fields)
        {
            _fields = fields;
        }

        public string this[Field.Definition fieldDefinition] => _fields[fieldDefinition.Index].Trim();
    }
}
