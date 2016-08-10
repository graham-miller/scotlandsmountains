﻿using System.IO;

namespace ScotlandsMountains.Resources
{
    public static class Load
    {
        public static class Dobih
        {
            public static Stream HillCsvZip()
            {
                return typeof(Load)
                    .Assembly
                    .GetManifestResourceStream(typeof(Load).Namespace + ".Raw.Dobih.hillcsv.zip");
            }
        }
    }
}
