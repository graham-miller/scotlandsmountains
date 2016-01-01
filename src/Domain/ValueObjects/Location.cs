namespace ScotlandsMountains.Domain.ValueObjects
{
    public class Location
    {
        protected Location() { }

        public Location(double latitude, double longitude, string sixFigureGridReference, string tenFigureGridReference = null)
        {
            Latitude = latitude;
            Longitude = longitude;
            GridReference = new GridReference(sixFigureGridReference, tenFigureGridReference);
        }

        public double Latitude { get; set; }
        
        public double Longitude { get; set; }

        public GridReference GridReference { get; set; }
    }
}