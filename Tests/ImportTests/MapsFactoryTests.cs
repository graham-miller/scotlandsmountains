using Moq;
using NUnit.Framework;
using ScotlandsMountains.Import;
using ScotlandsMountains.Import.Os;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private Maps _sut;

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

            _sut = new MapsFactory(mockIdGenerator.Object).BuildFrom(mockOsFile.Object);
        }

        [Test]
        public void GivenLandrangerRecordsWhenBuildingThenMappedCorrectly()
        {
            var actual = _sut.Landranger.First();

            Assert.That(actual.Id, Is.EqualTo(Id));
            Assert.That(actual.Publisher, Is.EqualTo(MapConstants.OrdnanceSurvey));
            Assert.That(actual.Series, Is.EqualTo(MapConstants.Landranger));
            Assert.That(actual.Code, Is.EqualTo(Code));
            Assert.That(actual.Name, Is.EqualTo(Name));
            Assert.That(actual.Isbn, Is.EqualTo(Isbn));
            Assert.That(actual.Scale, Is.EqualTo(MapConstants.OneTo50K));
        }

        [Test]
        public void GivenLandrangerActiveRecordsWhenBuildingThenMappedCorrectly()
        {
            var actual = _sut.LandrangerActive.First();

            Assert.That(actual.Id, Is.EqualTo(Id));
            Assert.That(actual.Publisher, Is.EqualTo(MapConstants.OrdnanceSurvey));
            Assert.That(actual.Series, Is.EqualTo(MapConstants.LandrangerActive));
            Assert.That(actual.Code, Is.EqualTo(Code));
            Assert.That(actual.Name, Is.EqualTo(Name));
            Assert.That(actual.Isbn, Is.EqualTo(Isbn));
            Assert.That(actual.Scale, Is.EqualTo(MapConstants.OneTo50K));
        }

        [Test]
        public void GivenExplorerRecordsWhenBuildingThenMappedCorrectly()
        {
            var actual = _sut.Explorer.First();

            Assert.That(actual.Id, Is.EqualTo(Id));
            Assert.That(actual.Publisher, Is.EqualTo(MapConstants.OrdnanceSurvey));
            Assert.That(actual.Series, Is.EqualTo(MapConstants.Explorer));
            Assert.That(actual.Code, Is.EqualTo(Code));
            Assert.That(actual.Name, Is.EqualTo(Name));
            Assert.That(actual.Isbn, Is.EqualTo(Isbn));
            Assert.That(actual.Scale, Is.EqualTo(MapConstants.OneTo25K));
        }

        [Test]
        public void GivenExplorerActiveRecordsWhenBuildingThenMappedCorrectly()
        {
            var actual = _sut.ExplorerActive.First();

            Assert.That(actual.Id, Is.EqualTo(Id));
            Assert.That(actual.Publisher, Is.EqualTo(MapConstants.OrdnanceSurvey));
            Assert.That(actual.Series, Is.EqualTo(MapConstants.ExplorerActive));
            Assert.That(actual.Code, Is.EqualTo(Code));
            Assert.That(actual.Name, Is.EqualTo(Name));
            Assert.That(actual.Isbn, Is.EqualTo(Isbn));
            Assert.That(actual.Scale, Is.EqualTo(MapConstants.OneTo25K));
        }

        [Test]
        public void GivenDiscovererRecordsWhenBuildingThenMappedCorrectly()
        {
            var actual = _sut.Discoverer.First();

            Assert.That(actual.Id, Is.EqualTo(Id));
            Assert.That(actual.Publisher, Is.EqualTo(MapConstants.OrdnanceSurvey));
            Assert.That(actual.Series, Is.EqualTo(MapConstants.Discoverer));
            Assert.That(actual.Code, Is.EqualTo(Code));
            Assert.That(actual.Name, Is.EqualTo(Name));
            Assert.That(actual.Isbn, Is.EqualTo(Isbn));
            Assert.That(actual.Scale, Is.EqualTo(MapConstants.OneTo50K));
        }

        [Test]
        public void GivenDiscoveryRecordsWhenBuildingThenMappedCorrectly()
        {
            var actual = _sut.Discovery.First();

            Assert.That(actual.Id, Is.EqualTo(Id));
            Assert.That(actual.Publisher, Is.EqualTo(MapConstants.OrdnanceSurvey));
            Assert.That(actual.Series, Is.EqualTo(MapConstants.Discovery));
            Assert.That(actual.Code, Is.EqualTo(Code));
            Assert.That(actual.Name, Is.EqualTo(Name));
            Assert.That(actual.Isbn, Is.EqualTo(Isbn));
            Assert.That(actual.Scale, Is.EqualTo(MapConstants.OneTo50K));
        }
    }
}
