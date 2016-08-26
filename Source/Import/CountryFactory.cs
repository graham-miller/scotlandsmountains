using System.Collections.Generic;
using System.Linq;
using ScotlandsMountains.Domain;
using ScotlandsMountains.Import.Dobih;

namespace ScotlandsMountains.Import
{
    public class CountryFactory
    {
        public CountryFactory(IIdGenerator idGenerator)
        {
            _idGenerator = idGenerator;
        }

        public IList<Country> BuildFrom(IDobihFile dobihFile)
        {
            return dobihFile.Records
                .Select(x => x.Country)
                .Where(x => x.Length == 1)
                .Distinct()
                .OrderBy(x => x)
                .Select(x => new Country
                {
                    Id = _idGenerator.Generate(),
                    Name = Lookup(x)
                })
                .ToList();
        }

        private static string Lookup(string countryCode)
        {
            switch (countryCode)
            {
                case "S":
                    return "Scotland";
                case "E":
                    return "England";
                case "W":
                    return "Wales";
                case "I":
                    return "Ireland";
                case "M":
                    return "Isle of Man";
                case "C":
                    return "Channel Islands";
                default:
                    throw new KeyNotFoundException($"The country code {countryCode} is not known");
            }
        }

        private readonly IIdGenerator _idGenerator;
    }
}
