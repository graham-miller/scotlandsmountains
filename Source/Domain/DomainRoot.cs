using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ScotlandsMountains.Domain
{
    public class DomainRoot
    {
        public IList<Mountain> Mountains { get; set; }

        public IList<Classification> Classifications { get; set; }

        public Maps Maps { get; set; }

        public static DomainRoot Load()
        {
            var json = Resources.Load.ScotlandsMountains.DomainJson;
            return JsonConvert.DeserializeObject<DomainRoot>(json, JsonSerializerSettings);
        } 

        public void Save()
        {
            var json = JsonConvert.SerializeObject(this, JsonSerializerSettings);
            Resources.Save.ScotlandsMountains.DomainJson(json);
        }

        private static readonly JsonSerializerSettings JsonSerializerSettings = new JsonSerializerSettings
        {
            Formatting = Formatting.Indented,
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };
    }
}
