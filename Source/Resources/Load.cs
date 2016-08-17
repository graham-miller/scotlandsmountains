using System.IO;

namespace ScotlandsMountains.Resources
{
    public static class Load
    {
        public static class Dobih
        {
            public static Stream HillCsvZip => Open("Dobih.hillcsv.zip");
        }

        public static class Os
        {
            public static Stream MapCatalogue => Open("OS.ordnance-survey-leisure-map-catalogue.pdf");
        }

        private static Stream Open(string path)
        {
            return typeof(Load).Assembly.GetManifestResourceStream($"{typeof(Load).Namespace}.Raw.{path}");
        }
    }
}
