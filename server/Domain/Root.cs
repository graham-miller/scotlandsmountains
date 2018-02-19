using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ScotlandsMountains.Domain
{
    public class Root
    {
        public Root() { }

        public Root(IList<DobihRecord> dobihRecords)
        {
            Mountains = dobihRecords.Select(x => new Mountain(x)).ToList();
            Sections = dobihRecords.Select(x => x.Region).Distinct().Select(x => new Section(x)).ToList();
            Classifications = Classification.Build();
            Countries = Country.Build();
            Maps = Map.Build(dobihRecords);

            LinkMountainsToRelatedEntities();
        }

        [JsonConverter(typeof(HasIdListJsonConverter<Mountain>))]
        public List<Mountain> Mountains { get; set; }

        [JsonConverter(typeof(HasIdListJsonConverter<Section>))]
        public List<Section> Sections { get; set; }

        [JsonConverter(typeof(HasIdListJsonConverter<Classification>))]
        public IList<Classification> Classifications { get; set; }

        [JsonConverter(typeof(HasIdListJsonConverter<Country>))]
        public IList<Country> Countries { get; set; }

        [JsonConverter(typeof(HasIdListJsonConverter<Map>))]
        public IList<Map> Maps { get; set; }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, JsonSerializerSettings);
        }

        public static Root FromJson(string json)
        {
            return JsonConvert.DeserializeObject<Root>(json, JsonSerializerSettings);
        }

        private static readonly JsonSerializerSettings JsonSerializerSettings = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            Formatting = Formatting.Indented
        };

        private void LinkMountainsToRelatedEntities()
        {
            foreach (var mountain in Mountains)
            {
                LinkMountainAndParent(mountain);
                LinkMountainAndCountries(mountain);

                LinkMountainAndClassifications(mountain);
                LinkMountainAndSections(mountain);
                LinkMountainAndMaps(mountain);
            }
        }

        private void LinkMountainAndParent(Mountain mountain)
        {
            if (mountain.DobihRecord.ParentMa == "0")
                return;

            mountain.ParentId = Mountains.Single(x => x.DobihRecord.Number == mountain.DobihRecord.ParentMa).Id;
        }

        private void LinkMountainAndCountries(Mountain mountain)
        {
            mountain.CountryId = Countries
                .Single(x => x.DobihCode == mountain.DobihRecord.Country)
                .Id;
        }

        private static readonly IList<PropertyInfo> ClassificationProperties =
            typeof(DobihRecord).GetProperties().Where(x => Attribute.IsDefined(x, typeof(DobihFieldNameAttribute))).ToList();

        private void LinkMountainAndClassifications(Mountain mountain)
        {
            var classificationCodes = ClassificationProperties
                .Where(x => x.GetValue(mountain.DobihRecord, null).ToString() == "1")
                .Select(x => ((DobihFieldNameAttribute)Attribute.GetCustomAttribute(x, typeof(DobihFieldNameAttribute))).Name)
                .ToList();

            var classifications = Classifications.Where(x => classificationCodes.Contains(x.DobihCode)).ToList();

            foreach (var classification in classifications)
                classification.MountainIds.Add(mountain.Id);

            mountain.ClassificationIds = classifications.Select(x => x.Id).ToList();
        }

        private void LinkMountainAndSections(Mountain mountain)
        {
            var section = Sections.Single(x => x.DobihSectionName == mountain.DobihRecord.Region);
            section.MountainIds.Add(mountain.Id);
            mountain.SectionId = section.Id;
        }

        private void LinkMountainAndMaps(Mountain mountain)
        {
            IList<Map> maps;

            if (mountain.DobihRecord.Country == Map.Ireland)
            {
                maps = Maps
                    .Where(x => x.Publisher == Map.OrdnanceSurveyIreland)
                    .Where(x => mountain.DobihRecord.Map1To50000.SplitMapCodes().Contains(x.Code))
                    .ToList();
            }
            else
            {
                maps = Maps
                    .Where(x => x.Series == Map.Landranger)
                    .Where(x => mountain.DobihRecord.Map1To50000.SplitMapCodes().Contains(x.Code))
                    .Concat(Maps
                        .Where(x => x.Series == Map.Explorer)
                        .Where(x => mountain.DobihRecord.Map1To25000.SplitMapCodes().Contains(x.Code)))
                    .ToList();
            }

            foreach (var map in maps)
                map.MountainIds.Add(mountain.Id);

            mountain.MapIds = maps.Select(x => x.Id).ToList();
        }
    }
}
