using System.Collections.Generic;
using System.Linq;
using ScotlandsMountains.Domain;
using ScotlandsMountains.Import.Dobih;

namespace ScotlandsMountains.Import.Providers
{
    public class MountainProvider : IEntityProvider<Mountain>
    {
        public MountainProvider(ImportParameters importParameters)
        {
            _importParameters = importParameters;
        }

        public IList<Mountain> GetAll()
        {
            return _importParameters.DobihFile.Records
                .Select(LoadMountain)
                .OrderByDescending(m => m.Height)
                .ToList();
        }

        public Mountain GetByDobihId(string dobihId)
        {
            throw new System.NotImplementedException();
        }

        private Mountain LoadMountain(IDobihRecord record)
        {
            return new Mountain
            {
                Id = _importParameters.IdGenerator.Generate(record.Number),
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
                Observations = record.Observations,
                ClassificationIds = null,
                MapIds = null,
                SectionId = null,
                CountryId = null
            };
        }

        private readonly ImportParameters _importParameters;
    }
}
