using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using NUnit.Framework;
using ScotlandsMountains.Domain.Dobih.Csv;
using ScotlandsMountains.Domain.Entities;
using ScotlandsMountains.Tests.Common;

namespace ScotlandsMountains.IntegrationTests
{
    [TestFixture]
    public class DobihCsvImporterTests : ArrangeActAssert<Importer>
    {
        private IList<Mountain> _actualMountains;
        private IList<Map> _actualMaps;
        private IList<Area> _actualAreas;
        private IList<Table> _actualTables;

        protected override void Arrange()
        {
            SubjectUnderTest = new Importer(GetPathToDobihCsv());
        }

        protected override void Act()
        {
            _actualMountains = SubjectUnderTest.Mountains;
            _actualMaps = SubjectUnderTest.Maps;
            _actualAreas = SubjectUnderTest.Areas;
            _actualTables = SubjectUnderTest.Tables;
        }

        [Test]
        public void CountOfTablesIsCorrect()
        {
            Assert.That(_actualTables.Count, Is.EqualTo(11));
        }

        [Test]
        public void CountOfMountainsIsCorrect()
        {
            Assert.That(_actualMountains.Count, Is.EqualTo(10792));
        }

        [Test]
        public void BenNevisIsCorrectlyMapped()
        {
            var benNevis = _actualMountains[0];

            Assert.That(benNevis.Name, Is.EqualTo("Ben Nevis"));

            Assert.That(benNevis.Height.Feet, Is.EqualTo(4409));
            Assert.That(benNevis.Height.Metres, Is.EqualTo(1344));

            Assert.That(benNevis.Location.GridReference.Letters, Is.EqualTo("NN"));
            Assert.That(benNevis.Location.GridReference.Eastings, Is.EqualTo("16676"));
            Assert.That(benNevis.Location.GridReference.Northings, Is.EqualTo("71283"));
            Assert.That(benNevis.Location.Latitude, Is.EqualTo(56.79685));
            Assert.That(benNevis.Location.Longitude, Is.EqualTo(-5.003508));
            Assert.That(benNevis.Location.Area.Name, Is.EqualTo("Fort William to Loch Treig and Loch Leven"));

            Assert.That(benNevis.Summit.Feature, Is.EqualTo("trig point on plinth"));
            Assert.That(benNevis.Summit.Observations, Is.EqualTo("man-made structure supporting emergency structure is higher"));

            Assert.That(benNevis.Maps.Count, Is.EqualTo(2));
            Assert.That(benNevis.Maps.Any(x => x.Code == 41));
            Assert.That(benNevis.Maps.Any(x => x.Code == 392));

            Assert.That(benNevis.DobihId, Is.EqualTo(278));

            Assert.That(benNevis.Tables.Count, Is.EqualTo(4));
            Assert.That(benNevis.Tables[0].Name, Is.EqualTo("Munro"));
            Assert.That(benNevis.Tables[1].Name, Is.EqualTo("Murdo"));
            Assert.That(benNevis.Tables[2].Name, Is.EqualTo("Marilyn"));
            Assert.That(benNevis.Tables[3].Name, Is.EqualTo("Tump"));
        }

        [Test]
        public void ParentIsCorrectlyMapped()
        {
            var carnNaCriche = _actualMountains[4];
            Assert.That(carnNaCriche.Parent.Name, Is.EqualTo("Braeriach"));
        }

        [Test]
        public void CountOfMapsIsCorrect()
        {
            Assert.That(_actualMaps.Count, Is.EqualTo(243));
        }

        [Test]
        public void CountOfAreasIsCorrect()
        {
            Assert.That(_actualAreas.Count, Is.EqualTo(70));
        }

        [Test]
        public void MountainsAreMappedToTables()
        {
            Assert.That(SubjectUnderTest.Tables[0].Mountains.Count, Is.EqualTo(282));
            Assert.That(SubjectUnderTest.Tables[1].Mountains.Count, Is.EqualTo(221));
            Assert.That(SubjectUnderTest.Tables[2].Mountains.Count, Is.EqualTo(223));
            Assert.That(SubjectUnderTest.Tables[3].Mountains.Count, Is.EqualTo(88));
            Assert.That(SubjectUnderTest.Tables[4].Mountains.Count, Is.EqualTo(227));
            Assert.That(SubjectUnderTest.Tables[5].Mountains.Count, Is.EqualTo(452));
            Assert.That(SubjectUnderTest.Tables[6].Mountains.Count, Is.EqualTo(774));
            Assert.That(SubjectUnderTest.Tables[7].Mountains.Count, Is.EqualTo(50));
            Assert.That(SubjectUnderTest.Tables[8].Mountains.Count, Is.EqualTo(442));
            Assert.That(SubjectUnderTest.Tables[9].Mountains.Count, Is.EqualTo(1217));
        }

        private string GetPathToDobihCsv()
        {
            var codeBase = Assembly.GetExecutingAssembly().CodeBase;
            var uri = new UriBuilder(codeBase);
            var path = Uri.UnescapeDataString(uri.Path);
            return Path.GetDirectoryName(path) + @"\DoBIH.csv";
        }
    }
}
