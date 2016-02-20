using System;
using System.Collections.Generic;
using System.Linq;
using ScotlandsMountains.Domain.Entities;
using ScotlandsMountains.Import.ConsoleApp.DatabaseOfBritishAndIrishHills;

namespace ScotlandsMountains.Import.ConsoleApp.OrdnanceSurvey
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
                .Select(x => new Map
                {
                    Code = x,
                    Scale = 0.00004m
                })
                .ToList();

            Maps1To50000 = records
                .SelectMany(r => r[Field.Map1To50K].Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries))
                .Distinct()
                .Where(x => !string.IsNullOrEmpty(x))
                .OrderBy(x => x)
                .Select(x => new Map
                {
                    Code = x,
                    Scale = 0.00002m
                })
                .ToList();
        }

        public IList<Map> Maps1To25000 { get; private set; }
        public IList<Map> Maps1To50000 { get; private set; }
    }
}