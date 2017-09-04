using System.Collections.Generic;
using Newtonsoft.Json;

namespace ScotlandsMountains.Import.Domain
{
    public class Country : HasKey
    {
        public string Name { get; set; }

        [JsonIgnore]
        public string DobihCode { get; set; }

        public static IList<Country> Build()
        {
            return new List<Country>
            {
                new Country {DobihCode = "S", Name = "Scotland"},
                new Country {DobihCode = "E", Name = "England"},
                new Country {DobihCode = "W", Name = "Wales"},
                new Country {DobihCode = "I", Name = "Ireland"},
                new Country {DobihCode = "M", Name = "Isle of Man"},
                new Country {DobihCode = "C", Name = "Channel Islands"},
                new Country {DobihCode = "ES", Name = "Scottish/English border"}
            };
        }
    }
}
