namespace ScotlandsMountains.Import.Domain
{
    public partial class DobihRecord
    {
        public string CleanedName => Name;

        public Location Location => new Location
        {
            GridRef = new GridRef(GridRef, string.IsNullOrEmpty(GridRef10) ? null : GridRef10),
            Latitude = double.Parse(Latitude),
            Longitude = double.Parse(Longitude)
        };

        public Height Height => new Height {Metres = double.Parse(Metres)};

        public Prominence Prominence => new Prominence
        {
            Drop = new Height {Metres = double.Parse(Drop)}
        };

        public int DobihNumber => int.Parse(Number);
    }
}