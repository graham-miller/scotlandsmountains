using System;
using System.Collections.Generic;
using System.Linq;
using ScotlandsMountains.Domain.Entities;

namespace ScotlandsMountains.Import.ConsoleApp.DatabaseOfBritishAndIrishHills.EntityFactories
{
    public class CountiesFactory
    {
        public CountiesFactory(IList<Record> records)
        {
            Counties = records
                .SelectMany(r => r[Field.County].SplitCounties())
                .Distinct()
                .Where(x => !string.IsNullOrEmpty(x))
                .OrderBy(x => x)
                .Select(x => new County {Name = x})
                .ToList();
        }

        public IList<County> Counties { get; private set; }
    }
}