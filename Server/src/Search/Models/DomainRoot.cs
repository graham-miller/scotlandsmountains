using ScotlandsMountains.Domain.Abstractions;
using System.Collections.Generic;
using ScotlandsMountains.Domain.Entities;
using System.IO;
using Newtonsoft.Json;

namespace Search.Models
{
    public class DomainRoot : IDomainRoot
    {
        public DomainRoot()
        {
            JsonConvert.PopulateObject(File.ReadAllText(@"C:\Users\Graham\GitHub\ScotlandsMountains\Docs\SearchData\search.json"), this);
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
