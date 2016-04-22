using ScotlandsMountains.Domain.Entities;
using System.Linq;

namespace ScotlandsMountains.Api.Models
{
    public class MountainSummary
    {
        private MountainSummary() { }

        public static MountainSummary Create(Mountain mountain)
        {
            if (mountain == null) return null;

            return new MountainSummary
            {
                Key = mountain.Key,
                Name = mountain.Name,
                Height = $"{mountain.Height.Metres.ToString("#,##0")}m ({mountain.Height.Feet.ToString("#,##0")}ft)",
                Classification = string.Join(", ", mountain.Classifications.Select(x => x.Name)),
                LatLong = new[] { mountain.Location.Latitude, mountain.Location.Longitude }
            };
        }

        public string Key { get; private set; }
        public string Name { get; private set; }
        public string Height { get; private set; }
        public string Classification { get; private set; }
        public double[] LatLong { get; private set; }
    }
}
