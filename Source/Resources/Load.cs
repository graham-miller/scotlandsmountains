using System;
using System.Diagnostics.CodeAnalysis;
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

        public static class ScotlandsMountains
        {
            public static string DomainJson
            {
                get
                {
                    using (var stream = Open("ScotlandsMountains.Domain.json"))
                    using (var reader = new StreamReader(stream))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
        }

        private static Stream Open(string path)
        {
            return typeof(Load).Assembly.GetManifestResourceStream($"{typeof(Load).Namespace}.Raw.{path}");
        }
    }

    public static class Save
    {
        public static class ScotlandsMountains
        {
            public static void DomainJson(string json)
            {
                var path = SolutionDirectory + @"\Source\Resources\Raw\ScotlandsMountains\Domain.json";
                File.WriteAllText(path, json);
            }
        }

        [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
        public static string SolutionDirectory
        {
            get
            {
                var codeBase = typeof(Load).Assembly.Location;
                var uri = new UriBuilder(codeBase);
                var path = Uri.UnescapeDataString(uri.Path);
                return new FileInfo(path).Directory.Parent.Parent.Parent.Parent.FullName;
            }
        }
    }
}
