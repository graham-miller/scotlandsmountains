using System.Collections.Generic;
using ScotlandsMountains.Domain.Entities;

namespace ScotlandsMountains.ImportConsole.Dobih.EntityFactories
{
    public class MountainsFactory
    {
        public MountainsFactory(IList<Record> records)
        {
            throw new System.NotImplementedException();
        }

        public IList<Mountain> Mountains { get; private set; }
    }
}