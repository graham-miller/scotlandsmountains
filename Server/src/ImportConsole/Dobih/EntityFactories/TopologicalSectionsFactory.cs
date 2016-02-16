using System.Collections.Generic;
using ScotlandsMountains.Domain.Entities;

namespace ScotlandsMountains.ImportConsole.Dobih.EntityFactories
{
    public class TopologicalSectionsFactory
    {
        public TopologicalSectionsFactory(IList<Record> records)
        {
            throw new System.NotImplementedException();
        }

        public IList<TopologicalSection> TopologicalSections { get; private set; }
    }
}