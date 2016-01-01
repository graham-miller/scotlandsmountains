using System.Configuration;
using System.IO;
using System.Web.Http;

namespace ScotlandsMountains.Web.Controllers
{
    public class ApiKeysController : ApiController
    {
        public string Get(string id)
        {
            if (id == "BingMaps")
                return GetBingMapsApiKey();

            return string.Empty;
        }

        private static string GetBingMapsApiKey()
        {
            var key = ConfigurationManager.AppSettings["BingMapsApiKey"];

            if(string.IsNullOrEmpty(key))
                using (var reader = new StreamReader(@"C:\Users\Graham\SkyDrive\ScotlandsMountains.API.keys.txt"))
                    key = reader.ReadLine();

            return key;
        }
    }
}