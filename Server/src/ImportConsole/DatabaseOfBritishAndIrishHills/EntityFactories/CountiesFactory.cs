using System;
using System.Collections.Generic;
using System.Linq;
using ScotlandsMountains.Domain.Entities;

namespace ScotlandsMountains.ImportConsole.DatabaseOfBritishAndIrishHills.EntityFactories
{
    public class CountiesFactory
    {
        public CountiesFactory(IList<Record> records)
        {
            Counties = records
                .SelectMany(r => r[Field.County].Split(new[] {"/"}, StringSplitOptions.RemoveEmptyEntries))
                .Distinct()
                .Where(x => !string.IsNullOrEmpty(x))
                .OrderBy(x => x)
                .Select((x, i) => new County
                {
                    Id = i + 1,
                    Name = x
                })
                .ToList();
        }

        public IList<County> Counties { get; private set; }
    }
}