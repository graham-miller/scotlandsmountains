using System.Collections.Generic;
using System.Linq;
using ScotlandsMountains.Domain;

namespace ScotlandsMountains.Import.Providers
{
    public class CountryProvider : IEntityProvider<Country>
    {
        public const string DobihCodeForScotland = "S";
        public const string DobihCodeForEngland = "E";
        public const string DobihCodeForEnglishScottishBorder = "ES";
        public const string DobihCodeForWales = "W";
        public const string DobihCodeForIreland = "I";
        public const string DobihCodeForChannelIslands = "C";
        public const string DobihCodeForIsleOfMan = "M";

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
            var id = dobihId == DobihCodeForEnglishScottishBorder ? DobihCodeForScotland : dobihId;
            return _countries[id];
        }

        private static Dictionary<string, Country> LoadCountries(IIdGenerator idGenerator)
        {
            var scotland = new Country {Id = idGenerator.Generate(), Name = "Scotland"};

            return new Dictionary<string, Country>
            {
                { DobihCodeForScotland, new Country {Id = idGenerator.Generate(), Name = "Scotland"} },
                //{ DobihCodeForEngland, new Country {Id = idGenerator.Generate(), Name = "England"} },
                //{ DobihCodeForWales, new Country {Id = idGenerator.Generate(), Name = "Wales"} },
                //{ DobihCodeForIreland, new Country {Id = idGenerator.Generate(), Name = "Ireland"} },
                //{ DobihCodeForChannelIslands, new Country {Id = idGenerator.Generate(), Name = "Channel Islands"} },
                //{ DobihCodeForIsleOfMan, new Country {Id = idGenerator.Generate(), Name = "Isle of Man"} }
            };
        }

        private readonly IDictionary<string, Country> _countries;
    }
}
