using System.Collections.Generic;
using System.Linq;

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
        }

        public List<Mountain> Mountains { get; set; }
        public List<Section> Sections { get; set; }
        public IList<Classification> Classifications { get; set; }
        public IList<Country> Countries { get; set; }
        public IList<Map> Maps { get; set; }

        public void LinkMountainsToRelatedEntities()
        {
            LinkMountainAndParent();
            LinkMountainAndClassifications();
            LinkMountainAndSections();
            LinkMountainAndMaps();
            LinkMountainAndCountries();
        }

        private void LinkMountainAndParent()
        {
            //TODO link mountain and Parent (SMC) and Parent (Ma), 
        }

        private void LinkMountainAndClassifications()
        {
            //TODO link mountain and classifications
        }

        private void LinkMountainAndSections()
        {
            foreach (var mountain in Mountains)
                mountain.SectionId = Sections.Single(x => x.DobihSectionName == mountain.DobihRecord.SectionName).Key;
        }

        private void LinkMountainAndMaps()
        {
            //TODO link mountain and maps
        }

        private void LinkMountainAndCountries()
        {
            foreach (var mountain in Mountains)
                mountain.CountryId = Countries.Single(x => x.DobihCode == mountain.DobihRecord.Country).Key;
        }
    }
}
