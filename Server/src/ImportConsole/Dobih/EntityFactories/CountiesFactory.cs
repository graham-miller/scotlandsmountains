using System.Collections.Generic;
using ScotlandsMountains.Domain.Entities;

namespace ScotlandsMountains.ImportConsole.Dobih.EntityFactories
{
    public class CountiesFactory
    {
        public CountiesFactory(IList<Record> records)
        {
            throw new System.NotImplementedException();
        }

        public IList<County> Counties { get; private set; }
    }
}