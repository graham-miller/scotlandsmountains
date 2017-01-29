using System.Collections.Generic;
using System.Linq;
using ScotlandsMountains.Domain;
using ScotlandsMountains.Import.Dobih;
using ScotlandsMountains.Import.Os;

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
                ListIds = GetListIdsFor(record),
                MapIds = GetMapIdsFor(record),
                SectionId = GetSectionIdFor(record),
                CountryId = GetCountryIdFor(record)
            };
        }

        private IList<string> GetListIdsFor(IDobihRecord record)
        {
            return record.Lists
                .Select(x => _importParameters.ListProvider.GetByDobihId(x))
                .Where(x => x != null)
                .Select(x => x.Id)
                .ToList();
        }

        private IList<string> GetMapIdsFor(IDobihRecord record)
        {
            var region = record.Country == "I" ? MapConstants.Region.Ireland : MapConstants.Region.GreatBritain;

            return _importParameters.MapProvider.GetMapsByCode(MapConstants.OneTo50K, region, record.Maps1To50000).Select(x => x.Id)
                .Concat(_importParameters.MapProvider.GetMapsByCode(MapConstants.OneTo25K, region, record.Maps1To25000).Select(x => x.Id))
                .ToList();
        }


        private string GetSectionIdFor(IDobihRecord record)
        {
            return _importParameters.SectionProvider.GetByDobihId(record.SectionName).Id;
        }

        private string GetCountryIdFor(IDobihRecord record)
        {
            return _importParameters.CountryProvider.GetByDobihId(record.Country).Id;
        }

        private readonly ImportParameters _importParameters;
    }
}
