using System.IO;
using System.IO.Compression;

namespace ScotlandsMountains.Resources
{
    public static class Load
    {
        public static class Dobih
        {
            public static Stream HillCsvZip => Open(Namespaces.HillcsvZip);
        }

        public static class Os
        {
            public static Stream MapCatalogue => Open(Namespaces.MapCataloguePdf);
        }

        public static class ScotlandsMountains
        {
            public static string DomainJson
            {
                get
                {
                    using (var stream = Open(Namespaces.DomainZip))
                    using (var zip = new ZipArchive(stream, ZipArchiveMode.Read))
                    using (var entry = zip.GetEntry(FileNames.DomainJson).Open())
                    using (var reader = new StreamReader(entry))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }

            public static Stream ListInfo => Open(Namespaces.ListInfoXlsx);
        }

        private static Stream Open(string path)
        {
            return typeof(Load).Assembly.GetManifestResourceStream(path);
        }
    }
}
