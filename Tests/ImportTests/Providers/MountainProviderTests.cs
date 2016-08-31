﻿using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using ScotlandsMountains.Domain;
using ScotlandsMountains.Import;
using ScotlandsMountains.Import.Dobih;
using ScotlandsMountains.Import.Os;
using ScotlandsMountains.Import.Providers;

namespace ScotlandsMountains.ImportTests.Providers
{
    [TestFixture]
    public class MountainProviderTests
    {
        private const int Number = 1;
        private const string Id = "Id";
        private const string Name = "Name";
        private const double Metres = 2;
        private const double Latitude = 3;
        private const double Longitude = 4;
        private const string GridRef = "NM123456";
        private const double Drop = 5;
        private const string ColGridRef = "ColGridRef";
        private const double ColMetres = 6;
        private const string Feature = "Feature";
        private const string Observations = "Observations";
        private const string SectionCode = "Section code";
        private const string SectionName = "Section code";
        private const string SectionId = "Section ID";
        private const string Classification1 = "Classification 1";
        private const string Classification2 = "Classification 2";
        private const string Classification1Id = "Classification 1 ID";
        private const string Classification2Id = "Classification 2 ID";
        private const string Country = "Country";
        private const string CountryId = "Country ID";
        private const string Map1To50K1 = "Map 1:50000 1";
        private const string Map1To50K2 = "Map 1:50000 2";
        private const string Map1To50K1Id = "Map 1:50000 1 ID";
        private const string Map1To50K2Id = "Map 1:50000 2 ID";
        private const string Map1To25K1 = "Map 1:25000 1";
        private const string Map1To25K2 = "Map 1:25000 2";
        private const string Map1To25K1Id = "Map 1:25000 1 ID";
        private const string Map1To25K2Id = "Map 1:25000 2 ID";
        private static readonly List<string> Classifications = new List<string> { Classification1, Classification2};
        private static readonly List<string> Maps1To50000 = new List<string> { Map1To50K1, Map1To50K2 };
        private static readonly List<string> Maps1To25000 = new List<string> { Map1To25K1, Map1To25K2 };

        private Mountain _actual;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var mockRecord = new Mock<IDobihRecord>();
            mockRecord.Setup(x => x.Number).Returns(Number);
            mockRecord.Setup(x => x.Name).Returns(Name);
            mockRecord.Setup(x => x.SectionCode).Returns(SectionCode);
            mockRecord.Setup(x => x.SectionName).Returns(SectionName);
            mockRecord.Setup(x => x.Country).Returns(Country);
            mockRecord.Setup(x => x.Classifications).Returns(Classifications);
            mockRecord.Setup(x => x.Maps1To50000).Returns(Maps1To50000);
            mockRecord.Setup(x => x.Maps1To25000).Returns(Maps1To25000);
            mockRecord.Setup(x => x.Metres).Returns(Metres);
            mockRecord.Setup(x => x.Latitude).Returns(Latitude);
            mockRecord.Setup(x => x.Longitude).Returns(Longitude);
            mockRecord.Setup(x => x.GridRef).Returns(GridRef);
            mockRecord.Setup(x => x.Drop).Returns(Drop);
            mockRecord.Setup(x => x.ColGridRef).Returns(ColGridRef);
            mockRecord.Setup(x => x.ColMetres).Returns(ColMetres);
            mockRecord.Setup(x => x.Feature).Returns(Feature);
            mockRecord.Setup(x => x.Observations).Returns(Observations);

            var mockDobihFile = new Mock<IDobihFile>();
            mockDobihFile.Setup(x => x.Records).Returns(new List<IDobihRecord> { mockRecord.Object });

            var mockIdGenerator = new Mock<IIdGenerator>();
            mockIdGenerator.Setup(x => x.Generate(Number)).Returns(Id);

            var mockCountryProvider = new Mock<IEntityProvider<Country>>();
            mockCountryProvider.Setup(x => x.GetByDobihId(Country)).Returns(new Country {Id = CountryId});

            var mockClassificationProvider = new Mock<IEntityProvider<Classification>>();
            mockClassificationProvider.Setup(x => x.GetByDobihId(Classification1)).Returns(new Classification {Id = Classification1Id});
            mockClassificationProvider.Setup(x => x.GetByDobihId(Classification2)).Returns(new Classification {Id = Classification2Id});

            var mockSectionProvider = new Mock<IEntityProvider<Section>>();
            mockSectionProvider.Setup(x => x.GetByDobihId(SectionName)).Returns(new Section { Id = SectionId });

            var mockMapProvider = new Mock<IMapProvider>();
            mockMapProvider
                .Setup(x => x.GetMapsByCode(It.IsAny<decimal>(), It.IsAny<MapConstants.Region>(), Maps1To50000))
                .Returns(new List<Map> { new Map { Id = Map1To50K1Id }, new Map { Id = Map1To50K2Id } });
            mockMapProvider
                .Setup(x => x.GetMapsByCode(It.IsAny<decimal>(), It.IsAny<MapConstants.Region>(), Maps1To25000))
                .Returns(new List<Map> { new Map { Id = Map1To25K1Id }, new Map { Id = Map1To25K2Id } });

            var parameters = new ImportParameters
            {
                DobihFile = mockDobihFile.Object,
                IdGenerator = mockIdGenerator.Object,
                CountryProvider = mockCountryProvider.Object,
                ClassificationProvider = mockClassificationProvider.Object,
                SectionProvider = mockSectionProvider.Object,
                MapProvider = mockMapProvider.Object
            };

            _actual = new MountainProvider(parameters).GetAll().Single();
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

        [Test]
        public void ThenProminenceIsMappedCorectly()
        {
            Assert.That(_actual.Prominence.Metres, Is.EqualTo(Drop));
            Assert.That(_actual.Prominence.KeyCol, Is.EqualTo(ColGridRef));
            Assert.That(_actual.Prominence.KeyColHeight.Metres, Is.EqualTo(ColMetres));
        }

        [Test]
        public void ThenFeatureIsMappedCorectly()
        {
            Assert.That(_actual.Feature, Is.EqualTo(Feature));
        }

        [Test]
        public void ThenObservationsIsMappedCorectly()
        {
            Assert.That(_actual.Observations, Is.EqualTo(Observations));
        }

        [Test]
        public void ThenCountryIdIsMappedCorectly()
        {
            Assert.That(_actual.CountryId, Is.EqualTo(CountryId));
        }

        [Test]
        public void ThenSectionIdIsMappedCorectly()
        {
            Assert.That(_actual.SectionId, Is.EqualTo(SectionId));
        }

        [Test]
        public void ThenClassificationIdsAreMappedCorectly()
        {
            Assert.That(_actual.ClassificationIds, Has.Count.EqualTo(2));
            Assert.That(_actual.ClassificationIds, Contains.Item(Classification1Id));
            Assert.That(_actual.ClassificationIds, Contains.Item(Classification2Id));
        }

        [Test]
        public void ThenMapIdsAreMappedCorectly()
        {
            Assert.That(_actual.MapIds, Has.Count.EqualTo(4));
            Assert.That(_actual.MapIds, Contains.Item(Map1To50K1Id));
            Assert.That(_actual.MapIds, Contains.Item(Map1To50K2Id));
            Assert.That(_actual.MapIds, Contains.Item(Map1To25K1Id));
            Assert.That(_actual.MapIds, Contains.Item(Map1To25K2Id));
        }
    }
}
