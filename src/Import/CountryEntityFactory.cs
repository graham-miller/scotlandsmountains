using System.Collections.Generic;
using System.Linq;
using ScotlandsMountains.Domain;
using ScotlandsMountains.Import.DoBIH;

namespace ScotlandsMountains.Import
{
    internal class CountryEntityFactory
    {
        public IList<Country> Countries { get { return _lookup.Values.ToList(); } }

        private readonly IDictionary<string, Country> _lookup = new Dictionary<string, Country>();

        public CountryEntityFactory()
        {
            var scotland = new Country { Name = Constants.Scotland };

            _lookup = new Dictionary<string, Country>
                {
                    {Constants.ScotlandAbbreviation, scotland},
                    {Constants.BordersAbbreviation, scotland},
                    {Constants.EnglandAbbreviation, new Country {Name = Constants.England}},
                    {Constants.WalesAbbreviation, new Country {Name = Constants.Wales}},
                    {Constants.IrelandAbbreviation, new Country {Name = Constants.Ireland}},
                    {Constants.IsleOfManAbbreviation, new Country {Name = Constants.IsleOfMan}},
                    {Constants.ChannelIslandsAbbreviation, new Country {Name = Constants.ChannelIslands}}
                };
        }

        public Country GetCountry(string dobihCountryCode)
        {
            return _lookup[dobihCountryCode];
        }
    }
}