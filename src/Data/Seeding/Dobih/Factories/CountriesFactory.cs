using System.Collections.Generic;
using ScotlandsMountains.Data.Seeding.DatabaseOfBritishAndIrishHills.Wrappers;

namespace ScotlandsMountains.Data.Seeding.DatabaseOfBritishAndIrishHills.Factories
{
    internal class CountriesFactory
    {
        public static List<CountryWrapper> Build()
        {
            return new List<CountryWrapper>
            {
                new CountryWrapper("S", "Scotland"),
                new CountryWrapper("E", "England"),
                new CountryWrapper("W", "Wales"),
                new CountryWrapper("I", "Ireland"),
                new CountryWrapper("M", "Isle of Man"),
                new CountryWrapper("C", "Channel Islands")
            };
        }
    }
}