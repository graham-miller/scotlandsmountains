using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using ScotlandsMountains.Domain.Abstractions;
using ScotlandsMountains.Domain.Entities;
using System;

namespace ScotlandsMountains.Domain.Search
{
    public class Index : IDomainRoot
    {
        public Index()
        {
            using (var reader = new StreamReader(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\GitHub\ScotlandsMountains\Unified\Documents\SearchData\search.json"))
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
