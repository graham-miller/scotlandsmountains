using System.Collections.Generic;
using System.Linq;
using ScotlandsMountains.Domain.Entities;

namespace ScotlandsMountains.ImportConsole.DatabaseOfBritishAndIrishHills.EntityFactories
{
    public class IslandsFactory
    {
        public IslandsFactory(IList<Record> records)
        {
            Islands = records
                .Select(r => new
                {
                    Name = r[Field.Island]
                })
                .Distinct()
                .Where(x => !string.IsNullOrEmpty(x.Name))
                .OrderBy(x => x.Name)
                .Select((x, i) => new Island
                {
                    Id = i + 1,
                    Name = x.Name
                })
                .ToList();
        }

        public IList<Island> Islands { get; private set; }
    }
}