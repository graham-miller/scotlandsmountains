using ScotlandsMountains.Domain;
using ScotlandsMountains.Import.Dobih;

namespace ScotlandsMountains.Import
{
    internal static class LocationFactory
    {
        public static Location BuildFrom(Record record)
        {
            return new Location
                {
                    GridReference = record.GridRef,
                    Latitude = record.Latitude,
                    Longitude = record.Longitude
                };
        }
    }
}