using System.Collections.Generic;
using ScotlandsMountains.Domain.Entities;

namespace ScotlandsMountains.Importer.DatabaseOfBritishAndIrishHills.EntityFactories
{
    public class EntityFactory
    {
        public EntityFactory(IList<Record> records, IList<Map> maps, HashIds hashIds)
        {
            _hashIds = hashIds;

            Sections = new SectionsFactory(records, hashIds).Sections;
            Islands = new IslandsFactory(records, hashIds).Islands;
            Counties = new CountiesFactory(records, hashIds).Counties;
            TopologicalSections = new TopologicalSectionsFactory(records, hashIds).TopologicalSections;
            Maps = maps;
            Classifications = new ClassificationsFactory(hashIds).Classifications;
            Mountains = new MountainsFactory(records, this).Mountains;
        }

        public HashIds HashIds { get; }

        public IEnumerable<Section> Sections { get; }

        public IList<Island> Islands { get; }

        public IList<County> Counties { get; }

        public IList<TopologicalSection> TopologicalSections { get; }

        public IList<Map> Maps { get; }

        public IList<Classification> Classifications { get; }

        public IList<Mountain> Mountains { get; }

        public string NextHashId()
        {
            return _hashIds.Next();
        }

        private readonly HashIds _hashIds;
    }
}
