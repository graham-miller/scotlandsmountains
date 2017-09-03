using System.Collections.Generic;

namespace ScotlandsMountains.Import.Domain
{
    public class Classification
    {
        public string Name { get; set; }

        public string DobihCode { get; set; }

        public static IList<Classification> Build()
        {
            return new List<Classification>
            {
                new Classification {DobihCode = "Ma", Name = "Marilyn"},
                new Classification {DobihCode = "Ma=", Name = "Marilyn Twin"},
                new Classification {DobihCode = "Hu", Name = "Hump"},
                new Classification {DobihCode = "Hu=", Name = "Hump Twin"},
                new Classification {DobihCode = "Tu", Name = "Tump"},
                new Classification {DobihCode = "Tu=", Name = "Tump Twin"},
                new Classification {DobihCode = "Sim", Name = "Simm"},
                new Classification {DobihCode = "M", Name = "Munro"},
                new Classification {DobihCode = "MT", Name = "Munro Top"},
                new Classification {DobihCode = "F", Name = "Furth"},
                new Classification {DobihCode = "C", Name = "Corbett"},
                new Classification {DobihCode = "G", Name = "Graham"},
                new Classification {DobihCode = "D", Name = "Donald"},
                new Classification {DobihCode = "DT", Name = "Donald Top"},
                new Classification {DobihCode = "Mur", Name = "Murdo"},
                new Classification {DobihCode = "CT", Name = "Corbett Top"},
                new Classification {DobihCode = "GT", Name = "Graham Top"},
                new Classification {DobihCode = "Hew", Name = "Hewitt"},
                new Classification {DobihCode = "N", Name = "Nuttall"},
                new Classification {DobihCode = "5", Name = "Dewey"},
                new Classification {DobihCode = "5D", Name = "Donald Dewey"},
                new Classification {DobihCode = "5H", Name = "Highland Five"},
                new Classification {DobihCode = "4", Name = "Tump 400m to 499m"},
                new Classification {DobihCode = "3", Name = "Tump 300m to 399m"},
                new Classification {DobihCode = "2", Name = "Tump 200m to 299m"},
                new Classification {DobihCode = "1", Name = "Tump 100m to 199m"},
                new Classification {DobihCode = "1=", Name = "Tump 100m to 199m Twin"},
                new Classification {DobihCode = "0", Name = "Tump 0m to 99m"},
                new Classification {DobihCode = "W", Name = "Wainwright"},
                new Classification {DobihCode = "WO", Name = "Wainwright Outlying Fell"},
                new Classification {DobihCode = "B", Name = "Birkett"},
                new Classification {DobihCode = "CoH", Name = "County Top (Historic)"},
                new Classification {DobihCode = "CoH=", Name = "County Top (Historic Twin)"},
                new Classification {DobihCode = "CoU", Name = "County Top (Current County and Unitary Authority)"},
                new Classification {DobihCode = "CoU=", Name = "County Top (CurrentCounty and Unitary Authority Twin)"},
                new Classification {DobihCode = "CoA", Name = "County Top (Administrative)"},
                new Classification {DobihCode = "CoA=", Name = "County Top (Administrative Twin)"},
                new Classification {DobihCode = "CoL", Name = "County Top (London Borough)"},
                new Classification {DobihCode = "CoL=", Name = "County Top (London Borough Twin)"},
                new Classification {DobihCode = "SIB", Name = "Significant Island of Britain"},
                new Classification {DobihCode = "sMa", Name = "Sub Marylin"},
                new Classification {DobihCode = "sHu", Name = "Sub Hump"},
                new Classification {DobihCode = "sSim", Name = "Sub Simm"},
                new Classification {DobihCode = "s5", Name = "Sub Dewey"},
                new Classification {DobihCode = "s5D", Name = "Sub Donald Dewey"},
                new Classification {DobihCode = "s5H", Name = "Sub Highland Five"},
                new Classification {DobihCode = "s5M", Name = "Sub Myrddyn Dewey"},
                new Classification {DobihCode = "s4", Name = "Sub Tump 400m to 499m"},
                new Classification {DobihCode = "Sy", Name = "Synge"},
                new Classification {DobihCode = "Fel", Name = "Fellranger"},
                new Classification {DobihCode = "BL", Name = "Buxton & Lewis"},
                new Classification {DobihCode = "Bg", Name = "Bridge"},
                new Classification {DobihCode = "T100", Name = "Trail 100"},
                new Classification {DobihCode = "xMT", Name = "Deleted Munro Top"},
                new Classification {DobihCode = "xC", Name = "Deleted Corbett"},
                new Classification {DobihCode = "xG", Name = "Deleted Graham"},
                new Classification {DobihCode = "xN", Name = "Deleted Nuttall"},
                new Classification {DobihCode = "xDT", Name = "Deleted Donald Top"},
                new Classification {DobihCode = "Dil", Name = "Dillon"},
                new Classification {DobihCode = "VL", Name = "Vandeleur-Lynam"},
                new Classification {DobihCode = "A", Name = "Arderin"},
                new Classification {DobihCode = "5M", Name = "Myrddyn Dewey"},
                new Classification {DobihCode = "Ca", Name = "Carn"},
                new Classification {DobihCode = "Bin", Name = "Binnion"},
                new Classification {DobihCode = "O", Name = "Other"},
                new Classification {DobihCode = "Un", Name = "Unclassified"}
            };
        }
    }
}
