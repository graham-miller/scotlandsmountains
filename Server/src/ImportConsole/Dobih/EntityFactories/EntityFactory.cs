using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using ScotlandsMountains.Domain.Entities;
using Newtonsoft.Json.Serialization;

namespace ScotlandsMountains.ImportConsole.Dobih.EntityFactories
{
    public class EntityFactory
    {
        public EntityFactory(IList<Record> records)
        {
            Sections = new SectionsFactory(records).Sections;
            Islands = new IslandsFactory(records).Islands;
            Counties = new CountiesFactory(records).Counties;
            TopologicalSections = new TopologicalSectionsFactory(records).TopologicalSections;
            Maps1To25000 = new MapsFactory(records).Maps1To25000;
            Maps1To50000 = new MapsFactory(records).Maps1To50000;

            //Mountains = new MountainsFactory(records).Mountains;
        }

        public IList<Section> Sections { get; }
        public IList<Island> Islands { get; }
        public IList<County> Counties { get; }
        public IList<TopologicalSection> TopologicalSections { get; }
        public IList<Map> Maps1To25000 { get; }
        public IList<Map> Maps1To50000 { get; }
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
