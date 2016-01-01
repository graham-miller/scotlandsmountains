using System.Linq;
using NUnit.Framework;
using ScotlandsMountains.Data;

namespace ScotlandsMountains.Import.Tests
{
    [TestFixture]
    public class Fiddle
    {
        //private const string RootFolder = @"C:\Users\Graham\GitHub\ScotlandsMountains3\docs";
        private const string RootFolder = @"U:\GitHub\ScotlandsMountains3\docs";

        private const string MountainsFilePath = RootFolder + @"\DoBIH\DoBIH_v14_1.csv";
        private const string ExplorerMapsFilePath = RootFolder + @"\OrdnanceSurvey\OsExplorerMaps.txt";
        private const string ExplorerMapsActiveFilePath = RootFolder + @"\OrdnanceSurvey\OsExplorerMapsActive.txt";
        private const string LandrangerMapsFilePath = RootFolder + @"\OrdnanceSurvey\OsLandrangerMaps.txt";
        private const string LandrangerMapsActiveFilePath = RootFolder + @"\OrdnanceSurvey\OsLandrangerMapsActive.txt";
        private const string IrishDiscoverMapsFilePath = RootFolder + @"\OrdnanceSurvey\OsIrishDiscoveryMaps.txt";

        [Test]
        public void ImportFiddle()
        {
            var mountainRecords = new Dobih.Reader(MountainsFilePath);
            var mapRecords = new OrdnanceSurvey.Reader(ExplorerMapsFilePath, ExplorerMapsActiveFilePath, LandrangerMapsFilePath, LandrangerMapsActiveFilePath, IrishDiscoverMapsFilePath);
            var factory = new EntityFactory(mountainRecords,mapRecords);
            var session = SessionFactory.Instance.OpenSession();

            using (var transaction = session.BeginTransaction())
            {
                foreach (var classification in factory.Classifications)
                    session.SaveOrUpdate(classification);

                foreach (var country in factory.MapPublishers)
                    session.SaveOrUpdate(country);

                foreach (var country in factory.MapSeries)
                    session.SaveOrUpdate(country);

                foreach (var country in factory.Maps)
                    session.SaveOrUpdate(country);

                foreach (var country in factory.Countries)
                    session.SaveOrUpdate(country);

                foreach (var area in factory.Areas)
                    session.SaveOrUpdate(area);

                foreach (var mountain in factory.Mountains.OrderByDescending(x => x.Height.Feet))
                    session.SaveOrUpdate(mountain);

                transaction.Commit();
            }
        }
    }
}
