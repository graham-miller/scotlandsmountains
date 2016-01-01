using System;
using System.Globalization;
using Newtonsoft.Json;
using ScotlandsMountains.Domain.Entities;

namespace ScotlandsMountains.Web.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class MountainModel
    {
        public MountainModel(Mountain mountain)
        {
            Id = mountain.Id.ToString(CultureInfo.InvariantCulture);
            Name = mountain.Name;
            Description = String.Format(
                "{0}ft ({1}m) - {2}",
                mountain.Height.Feet.ToString("#,##0"),
                mountain.Height.Metres.ToString("#,##0"),
                mountain.Tables[0].Name);
            Latitude = mountain.Location.Latitude;
            Longitude = mountain.Location.Longitude;
        }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("latitude")]
        public double Latitude { get; set; }
        
        [JsonProperty("longitude")]
        public double Longitude { get; set; }
    }
}