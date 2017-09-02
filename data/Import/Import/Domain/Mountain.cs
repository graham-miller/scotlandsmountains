using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScotlandsMountains.Import.Domain
{
    public class Mountain
    {
        public Mountain(DobihRecord dobihRecord)
        {
            Name = dobihRecord.CleanedName;
            Location = dobihRecord.Location;
            Height = dobihRecord.Height;
            Prominence = dobihRecord.Prominence;
            DobihNumber = dobihRecord.DobihNumber;
        }

        public string Name { get; set; }
        public Location Location { get; set; }
        public Height Height { get; set; }
        public Prominence Prominence { get; set; }
        public int DobihNumber { get; set; }
    }

    public class Prominence
    {
        public Height Drop { get; set; }
    }
}
