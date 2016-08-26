using System.Collections.Generic;
using System.Linq;
using ScotlandsMountains.Domain;
using ScotlandsMountains.Import.Dobih;

namespace ScotlandsMountains.Import
{
    public class MountainsFactory
    {
        private readonly IIdGenerator _idGenerator;
        private readonly IDomainRoot _domainRoot;

        public MountainsFactory(IIdGenerator idGenerator, IDomainRoot domainRoot)
        {
            _idGenerator = idGenerator;
            _domainRoot = domainRoot;
        }

        public IList<Mountain> BuildFrom(IDobihFile file)
        {
            return file.Records
                .Select(Build)
                .OrderByDescending(m => m.Height)
                .ToList();
        }

        private Mountain Build(IDobihRecord record)
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
                },
                Prominence = new Prominence
                {
                    Metres = record.Drop,
                    KeyCol = record.ColGridRef,
                    KeyColHeight = new Height {Metres = record.ColMetres}
                },
                Feature = record.Feature,
                Observations = record.Observations
            };
        }
    }
}
