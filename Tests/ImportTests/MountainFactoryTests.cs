using Moq;
using NUnit.Framework;
using ScotlandsMountains.Import;
using ScotlandsMountains.Import.Dobih;
using System.Collections.Generic;
using System.Linq;
using ScotlandsMountains.Domain;

namespace ScotlandsMountains.ImportTests
{
    [TestFixture]
    public class MountainFactoryTests
    {
        private const int Number = 1;
        private const string Id = "Id";
        private const string Name = "Name";
        private const double Metres = 2;
        private const double Latitude = 3;
        private const double Longitude = 4;
        private const string GridRef = "NM123456";

        private Mountain _actual;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var mockRecord = new Mock<IDobihRecord>();
            mockRecord.Setup(x => x.Number).Returns(Number);
            mockRecord.Setup(x => x.Name).Returns(Name);
            //mockRecord.Setup(x => x.Section).Returns();
            //mockRecord.Setup(x => x.Classifications).Returns();
            //mockRecord.Setup(x => x.Maps1To50000).Returns();
            //mockRecord.Setup(x => x.Maps1To25000).Returns();
            mockRecord.Setup(x => x.Metres).Returns(Metres);
            mockRecord.Setup(x => x.Latitude).Returns(Latitude);
            mockRecord.Setup(x => x.Longitude).Returns(Longitude);
            mockRecord.Setup(x => x.GridRef).Returns(GridRef);

            var mockIdGenerator = new Mock<IIdGenerator>();

            mockIdGenerator.Setup(x => x.Generate(Number)).Returns(Id);


            var mockDobihFile = new Mock<IDobihFile>();
            mockDobihFile.Setup(x => x.Records).Returns(new List<IDobihRecord> { mockRecord.Object });

            _actual = new MountainsFactory(mockIdGenerator.Object).BuildFrom(mockDobihFile.Object).Single();
        }

        [Test]
        public void ThenIdIsMappedCorrectly()
        {
            Assert.That(_actual.Id, Is.EqualTo(Id));
        }
        
        [Test]
        public void ThenNameIsMappedCorrectly()
        {
            Assert.That(_actual.Name, Is.EqualTo(Name));
        }

        [Test]
        public void ThenHeightIsMappedCorrectly()
        {
            Assert.That(_actual.Height.Metres, Is.EqualTo(Metres));
        }

        [Test]
        public void ThenLocationIsMappedCorrectly()
        {
            Assert.That(_actual.Location.Latitude, Is.EqualTo(Latitude));
            Assert.That(_actual.Location.Longitude, Is.EqualTo(Longitude));
            Assert.That(_actual.Location.GridRef.SixFigure, Is.EqualTo(GridRef));
        }
    }
}
