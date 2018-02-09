using System.Configuration;

namespace ScotlandsMountains.Import
{
    internal static class Configuration
    {
        public static string HillCsvUrl => ConfigurationManager.AppSettings["HillCsvUrl"];
    }
}
