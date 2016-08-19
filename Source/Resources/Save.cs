using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace ScotlandsMountains.Resources
{
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
        private static string SolutionDirectory
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
