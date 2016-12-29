using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace ScotlandsMountains.Resources
{
    public static class Namespaces
    {
        public static readonly string HillcsvZip = $"{Base}.Dobih.hillcsv.zip";

        public static readonly string MapCataloguePdf = $"{Base}.OS.ordnance-survey-leisure-map-catalogue.pdf";

        public static readonly string ListInfoXlsx = $"{Base}.ScotlandsMountains.ListInfo.xlsx";

        public static readonly string DomainZip = $"{Base}.ScotlandsMountains.{FileNames.DomainJson}.zip";

        public static string Base => $"{typeof(Namespaces).Namespace}.Raw";
    }

    public static class FileNames
    {
        public const string DomainJson = "Domain.json";
    }

    public static class Paths
    {
        public static readonly string DomainZip = Directories.Solution + @"\Source\Resources\Raw\ScotlandsMountains\Domain.json.zip";
    }

    public static class Directories
    {
        [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
        public static string Solution
        {
            get
            {
                var codeBase = typeof (Load).Assembly.Location;
                var uri = new UriBuilder(codeBase);
                var path = Uri.UnescapeDataString(uri.Path);
                return new FileInfo(path).Directory.Parent.Parent.Parent.Parent.FullName;
            }
        }
    }
}
