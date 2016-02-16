using System.Collections.Generic;
using ScotlandsMountains.Domain.Entities;

//Section, e.g. 01A
//Section name, e.g. 01A: Loch Tay to Perth

//Island

//Topo Section

//County

//Map 1:50k, e.g. 51 52
//Map 1:25k, e.g.OL47W 368W 379W

namespace ScotlandsMountains.ImportConsole.Dobih.EntityFactories
{
    public class EntityFactory
    {
        public EntityFactory(IList<Record> records)
        {
            Sections = new SectionsFactory(records).Sections;
            //Islands = new IslandsFactory(records).Islands;
            //Counties = new CountiesFactory(records).Counties;
            //TopologicalSections = new TopologicalSectionsFactory(records).TopologicalSections;
            //Maps = new MapsFactory(records).Maps;

            //Mountains = new MountainsFactory(records).Mountains;
        }

        public IList<Section> Sections { get; private set; }
        public IList<Island> Islands { get; private set; }
        public IList<County> Counties { get; private set; }
        public IList<TopologicalSection> TopologicalSections { get; set; }
        public IList<Map> Maps { get; set; }
        public IList<Mountain> Mountains { get; set; }
    }
}
