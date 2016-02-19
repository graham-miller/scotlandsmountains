using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ScotlandsMountains.Domain.Entities;

namespace ScotlandsMountains.ImportConsole.DatabaseOfBritishAndIrishHills.EntityFactories
{
    public class EntityFactory
    {
        public EntityFactory(IList<Record> records, IList<Map> maps)
        {
            Sections = new SectionsFactory(records).Sections;
            Islands = new IslandsFactory(records).Islands;
            Counties = new CountiesFactory(records).Counties;
            TopologicalSections = new TopologicalSectionsFactory(records).TopologicalSections;
            Maps = maps;
            Mountains = new MountainsFactory(records, this).Mountains;
        }

        public IList<Section> Sections { get; }
        public IList<Island> Islands { get; }
        public IList<County> Counties { get; }
        public IList<TopologicalSection> TopologicalSections { get; }
        public IList<Map> Maps { get; }
        public IList<Mountain> Mountains { get; }

        public void CreateFirebaseJson(string path)
        {
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            var json = JsonConvert.SerializeObject(this, Formatting.Indented, settings);

            using (var writer = new StreamWriter(path))
                writer.Write(json);
        }
    }
}
