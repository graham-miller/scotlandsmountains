using System.Collections.Generic;
using System.Linq;
using ScotlandsMountains.Domain;

namespace ScotlandsMountains.Import.Providers
{
    public class CountryProvider : IEntityProvider<Country>
    {
        public CountryProvider(IIdGenerator idGenerator)
        {
            _countries = LoadCountries(idGenerator);
        }

        public IList<Country> GetAll()
        {
            return _countries.Select(x => x.Value).ToList();
        }

        public Country GetByDobihId(string dobihId)
        {
            return _countries[dobihId];
        }

        private static Dictionary<string, Country> LoadCountries(IIdGenerator idGenerator)
        {
            var scotland = new Country {Id = idGenerator.Generate(), Name = "Scotland"};

            return new Dictionary<string, Country>
            {
                { "S", scotland },
                { "ES", scotland },
                { "E", new Country {Id = idGenerator.Generate(), Name = "England"} },
                { "W", new Country {Id = idGenerator.Generate(), Name = "Wales"} },
                { "I", new Country {Id = idGenerator.Generate(), Name = "Ireland"} },
                { "C", new Country {Id = idGenerator.Generate(), Name = "Channel Islands"} },
                { "M", new Country {Id = idGenerator.Generate(), Name = "Isle of Man"} }
            };
        }

        private readonly IDictionary<string, Country> _countries;
    }
}
