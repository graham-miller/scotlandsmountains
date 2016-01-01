using ScotlandsMountains.Domain.Entities;

namespace ScotlandsMountains.Data.Seeding.DatabaseOfBritishAndIrishHills.Wrappers
{
    internal class CountryWrapper
    {
        public CountryWrapper(string code, string name)
        {
            Code = code;
            Country = new Country(name);
        }

        public string Code { get; private set; }
        public Country Country { get; private set; }
    }
}
