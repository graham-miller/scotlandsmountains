using System.Collections.Generic;
using System.Linq;
using ScotlandsMountains.Domain.Entities;

namespace ScotlandsMountains.Import.ConsoleApp.DatabaseOfBritishAndIrishHills.EntityFactories
{
    public class CountiesFactory
    {
        public CountiesFactory(IEnumerable<Record> records, HashIds hashIds)
        {
            Counties = records
                .SelectMany(r => r[Field.County].SplitCounties())
                .Distinct()
                .Where(x => !string.IsNullOrEmpty(x))
                .OrderBy(x => x)
                .Select(x => new County
                {
                    Key = hashIds.Next(),
                    Name = x
                })
                .ToList();
        }

        public IList<County> Counties { get; private set; }
    }
}