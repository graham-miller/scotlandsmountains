using System;
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
            Name = dobihRecord.Name;

            DobihNumber = int.Parse(dobihRecord.Number);
        }

        public string Name { get; set; }



        public int DobihNumber { get; set; }
    }
}
