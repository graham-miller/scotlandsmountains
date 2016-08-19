using System.Collections.Generic;
using Newtonsoft.Json;

namespace ScotlandsMountains.Domain
{
    public class DomainRoot
    {
        public IList<Mountain> Mountains { get; set; }
        public Maps Maps { get; set; }

        public static DomainRoot Load()
        {
            var json = Resources.Load.ScotlandsMountains.DomainJson;
            return JsonConvert.DeserializeObject<DomainRoot>(json);
        } 

        public void Save()
        {
            var json = JsonConvert.SerializeObject(this);
            Resources.Save.ScotlandsMountains.DomainJson(json);
        }
    }
}
