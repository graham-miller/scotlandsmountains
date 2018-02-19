using System;

namespace ScotlandsMountains.Domain
{
    public partial class DobihRecord
    {
        private const string Col = "Col";
        public string CleanedName => Name;

        public Location Location => new Location
        {
            GridRef = new GridRef(GridRef, GridRef10),
            Latitude = double.Parse(Latitude),
            Longitude = double.Parse(Longitude)
        };

        public Height Height => new Height { Metres = double.Parse(Metres) };

        public Prominence Prominence
        {
            get
            {
                var prominence = new Prominence
                {
                    Drop = new Height { Metres = double.Parse(Drop) },
                    Feature = Domain.GridRef.IsGridRef(ColGridRef) ? Col : ColGridRef,
                    FeatureHeight = new Height { Metres = double.Parse(ColHeight) }
                };

                if (prominence.Feature == Col)
                    prominence.ColGridRef = new GridRef(ColGridRef);

                return prominence;
            }
        }

        public int DobihNumber => int.Parse(Number);


    }
}