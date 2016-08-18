using ScotlandsMountains.Domain;
using ScotlandsMountains.Import.Dobih;

namespace ScotlandsMountains.Import
{
    public class MountainFactory
    {
        private readonly IIdGenerator _idGenerator;

        public MountainFactory(IIdGenerator idGenerator)
        {
            _idGenerator = idGenerator;
        }

        public Mountain BuildFrom(DobihRecord record)
        {
            return new Mountain
            {
                Id = _idGenerator.Generate(record.Number),
                Name = record.Name,
                Height = new Height
                {
                    Metres = record.Metres,
                },
                Location = new Location
                {
                    GridRef = new GridRef(record.GridRef),
                    Latitude = record.Latitude,
                    Longitude = record.Longitude
                }
            };
        }
    }
}
