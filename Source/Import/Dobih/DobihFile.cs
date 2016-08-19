using System.Collections.Generic;
using System.Linq;

namespace ScotlandsMountains.Import.Dobih
{
    public interface IDobihFile
    {
        IDictionary<string, int> ColumnIndexes { get; }
        IList<IDobihRecord> Records { get; }
    }

    public class DobihFile : IDobihFile
    {
        public DobihFile(IDobihFileReader dobihFileReader = null)
        {
            dobihFileReader = dobihFileReader ?? new DobihFileReader();

            ColumnIndexes = dobihFileReader.ColumnIndexes;
            Records = dobihFileReader.Lines.Select(x => new DobihRecord(x, this)).ToList<IDobihRecord>();
        }

        public IDictionary<string,int> ColumnIndexes { get; } 
        public IList<IDobihRecord> Records { get; }
    }
}
