using ScotlandsMountains.Domain;

namespace ScotlandsMountains.Web.Server.Models
{
    public class MountainSummaryModel
    {
        public MountainSummaryModel(Mountain mountain)
        {
            Id = mountain.Id;
            Name = mountain.Name;
            Height = mountain.Height.ToString();
            Latitude = mountain.Location.Latitude;
            Longitude = mountain.Location.Longitude;
        }

        public string Id { get; private set; }
        public string Name { get; private set; }
        public string Height { get; private set; }
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }
    }
}
