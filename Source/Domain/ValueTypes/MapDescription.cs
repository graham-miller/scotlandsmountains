using System.IO;
using System.Net;
using HtmlAgilityPack;

namespace ScotlandsMountains.Domain.ValueTypes
{
    public class MapDescription
    {
        public static string Get(string identifier)
        {
            string html;
            using (var response = HttpWebRequest.Create("https://www.ordnancesurvey.co.uk/shop/maps.html?mapsearch=" + identifier.Replace(" ", "+")).GetResponse())
            using (var stream = response.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
            }

            var document = new HtmlDocument();
            document.LoadHtml(html);

            var node = document.DocumentNode.SelectSingleNode("//h2[@class='product-name']");

            return node.InnerText;
        }


    }
}
