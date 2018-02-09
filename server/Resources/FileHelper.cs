using System.IO;

namespace ScotlandsMountains.Resources
{
    public class FileHelper
    {
        public static string BaseDirectory => Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Resources", "Files");

        public static string HillCsvPath => Path.Combine(BaseDirectory, "DoBIH.csv");
    }
}
