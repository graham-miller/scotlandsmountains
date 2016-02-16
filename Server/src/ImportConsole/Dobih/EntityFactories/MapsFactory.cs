using System;
using System.Collections.Generic;
using System.Linq;
using ScotlandsMountains.Domain.Entities;

namespace ScotlandsMountains.ImportConsole.Dobih.EntityFactories
{
    public class MapsFactory
    {
        public MapsFactory(IList<Record> records)
        {
            Maps1To25000 = records
                .SelectMany(r => r[Field.Map1To25K].Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries))
                .Distinct()
                .Where(x => !string.IsNullOrEmpty(x))
                .OrderBy(x => x)
                .Select((x, i) => new Map
                {
                    Id = i + 1,
                    Code = x,
                    Scale = 0.00004m
                })
                .ToList();

            Maps1To50000 = records
                .SelectMany(r => r[Field.Map1To50K].Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries))
                .Distinct()
                .Where(x => !string.IsNullOrEmpty(x))
                .OrderBy(x => x)
                .Select((x, i) => new Map
                {
                    Id = i + 1,
                    Code = x,
                    Scale = 0.00002m
                })
                .ToList();
        }

        public IList<Map> Maps1To25000 { get; private set; }
        public IList<Map> Maps1To50000 { get; private set; }
    }
}