using System.Collections.Generic;
using ScotlandsMountains.Domain.Entities;

namespace ScotlandsMountains.Import.ConsoleApp.DatabaseOfBritishAndIrishHills.EntityFactories
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
            Classifications = new ClassificationsFactory().Classifications;
        }

        public IEnumerable<Section> Sections { get; }

        public IList<Island> Islands { get; }

        public IList<County> Counties { get; }

        public IList<TopologicalSection> TopologicalSections { get; }

        public IList<Map> Maps { get; }

        public IList<Classification> Classifications { get; }

        public IList<Mountain> Mountains { get; }
    }
}
