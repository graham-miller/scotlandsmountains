using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ScotlandsMountains.Import.Extensions;

namespace ScotlandsMountains.Import.Domain
{
    public class Root
    {
        public Root(IList<DobihRecord> dobihRecords)
        {
            Mountains = dobihRecords.Select(x => new Mountain(x)).ToList();
            Sections = dobihRecords.Select(x => x.SectionName).Distinct().Select(x => new Section(x)).ToList();
            Classifications = Classification.Build();
            Countries = Country.Build();
            Maps = Map.Build(dobihRecords);

            LinkMountainsToRelatedEntities();
        }

        [JsonConverter(typeof(HasKeyListJsonConverter<Mountain>))]
        public List<Mountain> Mountains { get; set; }

        [JsonConverter(typeof(HasKeyListJsonConverter<Section>))]
        public List<Section> Sections { get; set; }

        [JsonConverter(typeof(HasKeyListJsonConverter<Classification>))]
        public IList<Classification> Classifications { get; set; }

        [JsonConverter(typeof(HasKeyListJsonConverter<Country>))]
        public IList<Country> Countries { get; set; }

        [JsonConverter(typeof(HasKeyListJsonConverter<Map>))]
        public IList<Map> Maps { get; set; }

        public string ToJson()
        {
            var settings = new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Formatting = Formatting.Indented
            };

            return JsonConvert.SerializeObject(this, settings);            
        }

        private void LinkMountainsToRelatedEntities()
        {
            foreach (var mountain in Mountains)
            {
                LinkMountainAndParent(mountain);
                LinkMountainAndClassifications(mountain);
                LinkMountainAndSections(mountain);
                LinkMountainAndMaps(mountain);
                LinkMountainAndCountries(mountain);
            }
        }

        private void LinkMountainAndParent(Mountain mountain)
        {
            if (mountain.DobihRecord.ParentMa == "0")
                return;

            mountain.ParentId = Mountains.Single(x => x.DobihRecord.Number == mountain.DobihRecord.ParentMa).Key;
        }

        private static readonly IList<PropertyInfo> ClassificationProperties =
            typeof(DobihRecord).GetProperties().Where(x => Attribute.IsDefined(x, typeof(DobihFieldNameAttribute))).ToList();

        private void LinkMountainAndClassifications(Mountain mountain)
        {
            var classificationCodes = ClassificationProperties
                .Where(x => x.GetValue(mountain.DobihRecord, null).ToString() == "1")
                .Select(x => ((DobihFieldNameAttribute) Attribute.GetCustomAttribute(x, typeof(DobihFieldNameAttribute))).Name)
                .ToList();

            mountain.ClassificationIds = Classifications.Where(x => classificationCodes.Contains(x.DobihCode)).Select(x => x.Key).ToList();
        }

        private void LinkMountainAndSections(Mountain mountain)
        {
            mountain.SectionId = Sections
                .Single(x => x.DobihSectionName == mountain.DobihRecord.SectionName)
                .Key;
        }

        private void LinkMountainAndMaps(Mountain mountain)
        {
            if (mountain.DobihRecord.Country == Map.Ireland)
            {
                mountain.MapIds = Maps
                    .Where(x => x.Publisher == Map.OrdnanceSurveyIreland)
                    .Where(x => mountain.DobihRecord.Map1To50000.SplitMapCodes().Contains(x.Code))
                    .Select(x => x.Key)
                    .ToList();
            }
            else
            {
                mountain.MapIds = Maps
                    .Where(x => x.Series == Map.Landranger)
                    .Where(x => mountain.DobihRecord.Map1To50000.SplitMapCodes().Contains(x.Code))
                    .Select(x => x.Key)
                    .Concat(Maps
                        .Where(x => x.Series == Map.Explorer)
                        .Where(x => mountain.DobihRecord.Map1To25000.SplitMapCodes().Contains(x.Code))
                        .Select(x => x.Key))
                    .ToList();
            }
        }

        private void LinkMountainAndCountries(Mountain mountain)
        {
            mountain.CountryId = Countries
                .Single(x => x.DobihCode == mountain.DobihRecord.Country)
                .Key;
        }
    }
}
