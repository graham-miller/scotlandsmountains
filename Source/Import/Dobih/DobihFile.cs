using ScotlandsMountains.Import.Providers;
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
            Records = dobihFileReader.Lines
                .Select(x => new DobihRecord(x, ColumnIndexes))
                .Where(IsScottish)
                .ToList<IDobihRecord>();
        }


        public bool IsScottish(DobihRecord dobihRecord)
        {
            return
                dobihRecord.Country == CountryProvider.DobihCodeForScotland ||
                dobihRecord.Country == CountryProvider.DobihCodeForEnglishScottishBorder;
        }

        public IDictionary<string,int> ColumnIndexes { get; } 
        public IList<IDobihRecord> Records { get; }
    }
}
