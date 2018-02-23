using System.IO;

namespace ScotlandsMountains.Resources
{
    public class FileHelper
    {
        public static string BaseDirectory => Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Resources", "Files");

        public static string HillCsvPath => Path.Combine(BaseDirectory, "DoBIH.csv");

        public static string RootJsonPath => Path.Combine(BaseDirectory, "Root.json");

        public static string ClassificationsIndexCacheJsonPath => Path.Combine(BaseDirectory, "Cache", "ClassificationsIndex.json");

        public static string ClassificationCacheJsonPath(string name) => Path.Combine(BaseDirectory, "Cache", $"{name.Replace(" ", "")}Classification.json");
    }
}
