using System.Collections.Generic;
using System.Linq;
using ScotlandsMountains.Domain.Entities;

namespace ScotlandsMountains.Import.ConsoleApp.DatabaseOfBritishAndIrishHills.EntityFactories
{
    public class IslandsFactory
    {
        public IslandsFactory(IEnumerable<Record> records, HashIds hashIds)
        {
            Islands = records
                .Select(r => new
                {
                    Name = r[Field.Island]
                })
                .Distinct()
                .Where(x => !string.IsNullOrEmpty(x.Name))
                .OrderBy(x => x.Name)
                .Select(x => new Island
                {
                    Key = hashIds.Next(),
                    Name = x.Name
                })
                .ToList();
        }

        public IList<Island> Islands { get; private set; }
    }
}