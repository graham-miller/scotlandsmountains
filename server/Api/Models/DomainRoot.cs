using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using ScotlandsMountains.Domain.Abstractions;
using ScotlandsMountains.Domain.Entities;

namespace ScotlandsMountains.Api.Models
{
    public class DomainRoot : IDomainRoot
    {
        public DomainRoot()
        {
            using (var stream = Resources.Get.SearchJson)
            using (var reader = new StreamReader(stream))
                JsonConvert.PopulateObject(reader.ReadToEnd(), this);
        }

        public IList<Classification> Classifications { get; set; }
        public IList<County> Counties { get; set; }
        public IList<Island> Islands { get; set; }
        public IList<Map> Maps { get; set; }
        public IList<Mountain> Mountains { get; set; }
        public IEnumerable<Section> Sections { get; set; }
        public IList<TopologicalSection> TopologicalSections { get; set; }
    }
}
