using Moq;
using NUnit.Framework;
using ScotlandsMountains.Import;
using ScotlandsMountains.Import.Os;
using System.Collections.Generic;
using System.Linq;
using ScotlandsMountains.Domain;

namespace ScotlandsMountains.ImportTests
{
    [TestFixture]
    public class MapsFactoryTests
    {
        private const string Id = "Id";
        private const string Code = "Code";
        private const string Name = "Name";
        private const string Isbn = "ISBN";

        private static readonly List<OsRecord> osRecords = new List<OsRecord>
            {
                new OsRecord
                {
                    Code = Code,
                    Name = Name,
                    Isbn = Isbn
                }
            };

        private Maps _actual;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var mockIdGenerator = new Mock<IIdGenerator>();
            mockIdGenerator
                .Setup(x => x.Generate())
                .Returns(Id);


            var mockOsFile = new Mock<IOsFile>();
            mockOsFile.Setup(x => x.LandrangerMaps).Returns(osRecords);
            mockOsFile.Setup(x => x.LandrangerActiveMaps).Returns(osRecords);
            mockOsFile.Setup(x => x.ExplorerMaps).Returns(osRecords);
            mockOsFile.Setup(x => x.ExplorerActiveMaps).Returns(osRecords);
            mockOsFile.Setup(x => x.DiscovererMaps).Returns(osRecords);
            mockOsFile.Setup(x => x.DiscoveryMaps).Returns(osRecords);

            _actual = new MapsFactory(mockIdGenerator.Object).BuildFrom(mockOsFile.Object);
        }

        [Test]
        public void GivenLandrangerRecordsWhenBuildingThenMappedCorrectly()
        {
            var map = _actual.Landranger.First();

            Assert.That(map.Id, Is.EqualTo(Id));
            Assert.That(map.Publisher, Is.EqualTo(MapConstants.OrdnanceSurvey));
            Assert.That(map.Series, Is.EqualTo(MapConstants.Landranger));
            Assert.That(map.Code, Is.EqualTo(Code));
            Assert.That(map.Name, Is.EqualTo(Name));
            Assert.That(map.Isbn, Is.EqualTo(Isbn));
            Assert.That(map.Scale, Is.EqualTo(MapConstants.OneTo50K));
        }

        [Test]
        public void GivenLandrangerActiveRecordsWhenBuildingThenMappedCorrectly()
        {
            var map = _actual.LandrangerActive.First();

            Assert.That(map.Id, Is.EqualTo(Id));
            Assert.That(map.Publisher, Is.EqualTo(MapConstants.OrdnanceSurvey));
            Assert.That(map.Series, Is.EqualTo(MapConstants.LandrangerActive));
            Assert.That(map.Code, Is.EqualTo(Code));
            Assert.That(map.Name, Is.EqualTo(Name));
            Assert.That(map.Isbn, Is.EqualTo(Isbn));
            Assert.That(map.Scale, Is.EqualTo(MapConstants.OneTo50K));
        }

        [Test]
        public void GivenExplorerRecordsWhenBuildingThenMappedCorrectly()
        {
            var map = _actual.Explorer.First();

            Assert.That(map.Id, Is.EqualTo(Id));
            Assert.That(map.Publisher, Is.EqualTo(MapConstants.OrdnanceSurvey));
            Assert.That(map.Series, Is.EqualTo(MapConstants.Explorer));
            Assert.That(map.Code, Is.EqualTo(Code));
            Assert.That(map.Name, Is.EqualTo(Name));
            Assert.That(map.Isbn, Is.EqualTo(Isbn));
            Assert.That(map.Scale, Is.EqualTo(MapConstants.OneTo25K));
        }

        [Test]
        public void GivenExplorerActiveRecordsWhenBuildingThenMappedCorrectly()
        {
            var map = _actual.ExplorerActive.First();

            Assert.That(map.Id, Is.EqualTo(Id));
            Assert.That(map.Publisher, Is.EqualTo(MapConstants.OrdnanceSurvey));
            Assert.That(map.Series, Is.EqualTo(MapConstants.ExplorerActive));
            Assert.That(map.Code, Is.EqualTo(Code));
            Assert.That(map.Name, Is.EqualTo(Name));
            Assert.That(map.Isbn, Is.EqualTo(Isbn));
            Assert.That(map.Scale, Is.EqualTo(MapConstants.OneTo25K));
        }

        [Test]
        public void GivenDiscovererRecordsWhenBuildingThenMappedCorrectly()
        {
            var map = _actual.Discoverer.First();

            Assert.That(map.Id, Is.EqualTo(Id));
            Assert.That(map.Publisher, Is.EqualTo(MapConstants.OrdnanceSurvey));
            Assert.That(map.Series, Is.EqualTo(MapConstants.Discoverer));
            Assert.That(map.Code, Is.EqualTo(Code));
            Assert.That(map.Name, Is.EqualTo(Name));
            Assert.That(map.Isbn, Is.EqualTo(Isbn));
            Assert.That(map.Scale, Is.EqualTo(MapConstants.OneTo50K));
        }

        [Test]
        public void GivenDiscoveryRecordsWhenBuildingThenMappedCorrectly()
        {
            var map = _actual.Discovery.First();

            Assert.That(map.Id, Is.EqualTo(Id));
            Assert.That(map.Publisher, Is.EqualTo(MapConstants.OrdnanceSurvey));
            Assert.That(map.Series, Is.EqualTo(MapConstants.Discovery));
            Assert.That(map.Code, Is.EqualTo(Code));
            Assert.That(map.Name, Is.EqualTo(Name));
            Assert.That(map.Isbn, Is.EqualTo(Isbn));
            Assert.That(map.Scale, Is.EqualTo(MapConstants.OneTo50K));
        }
    }
}
