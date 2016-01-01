using System;
using System.IO;
using System.Reflection;

namespace ScotlandsMountains.Data.Seeding
{
    public class ImportPath
    {
        /// <summary>
        /// ImportPath
        /// </summary>
        /// <param name="relativePath">The path to the import file relative to the solution folder</param>
        public ImportPath(string relativePath)
        {
            Relative = relativePath;
        }

        public string Relative { get; private set; }

        public string FullyQualified {
            get
            {
                var codeBase = Assembly.GetAssembly(typeof (ImportPath)).CodeBase;
                var uri = new UriBuilder(codeBase);
                var assemblyPath = Uri.UnescapeDataString(uri.Path);
                var assemblyDirectory = new DirectoryInfo(Path.GetDirectoryName(assemblyPath));
                return Path.Combine(assemblyDirectory.Parent.Parent.Parent.Parent.Parent.FullName, Relative);
            }
        }
    }
}