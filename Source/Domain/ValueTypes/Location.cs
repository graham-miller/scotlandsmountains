using ScotlandsMountains.Domain.Entities;

namespace ScotlandsMountains.Domain.ValueTypes
{
    public class Location
    {
        public Location() { }

        public Location(string gridReference, double latitude, double longitude, Area area)
        {
            GridReference = new GridReference(gridReference);
            Latitude = latitude;
            Longitude = longitude;
            Area = area;
        }

        public virtual GridReference GridReference { get; private set; }
        public virtual double Latitude { get; private set; }
        public virtual double Longitude { get; private set; }
        public virtual Area Area { get; private set; }
    }
}