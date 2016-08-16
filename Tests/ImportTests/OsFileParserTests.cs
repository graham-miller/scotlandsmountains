using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using ScotlandsMountains.Import;

namespace ScotlandsMountains.ImportTests
{
    [TestFixture]
    public class OsFileParserTests
    {
        [Test]
        public void CanParseLandrangerSectionOfCatalogue()
        {
            var mockReader = new Mock<IOsFileReader>();
            mockReader
                .Setup(x => x.ReadLines())
                .Returns(new List<string>
                {
                    "1   OS Landranger current editions",
                    "(1:50 000 scale – 2 cm to 1 km or 1¼ inch to 1 mile)",
                    "Price: £8.99    (£8.99 as from 24",
                    "th",
                    "February 2016) All Landranger maps",
                    "have been reprinted with a new Rebranded cover. Revision date of",
                    "the map data is listed in the Revised date column.",
                    "Landranger Title ISBN Pub date Edn Revised Date",
                    "1",
                    "Shetland – Yell, Unst and",
                    "Fetlar",
                    "9780319260999",
                    "24/02/16",
                    "Feb",
                    "2016",
                    "May 2015"
                });

            var sut = new OsFile(mockReader.Object, new OsFileParser());

            var actual = sut.LandrangerMaps.First();

            Assert.That(actual.Publisher, Is.EqualTo(MapConstants.OrdnanceSurvey));
            Assert.That(actual.Series, Is.EqualTo(MapConstants.Landranger));
            Assert.That(actual.Code, Is.EqualTo("1"));
            Assert.That(actual.Name, Is.EqualTo("Shetland – Yell, Unst and Fetlar"));
            Assert.That(actual.Isbn, Is.EqualTo("9780319260999"));
            Assert.That(actual.Scale, Is.EqualTo(MapConstants.OneTo50K));
        }

        [Test]
        public void CanParseLandrangerActiveSectionOfCatalogue()
        {
            var mockReader = new Mock<IOsFileReader>();
            mockReader
                .Setup(x => x.ReadLines())
                .Returns(new List<string>
                {
                    "2  OS Landranger – Active current editions",
                    "(1:50 000 scale – 2 cm to 1 km or 1¼ inch to 1 mile)",
                    "Price: £14.99    (£14.99 as from 24",
                    "th",
                    "February 2016) All Landranger",
                    "Active maps have been reprinted with a new Rebranded cover.",
                    "Revision date of the map data is listed in the Revised date column.",
                    "Landranger",
                    "Active",
                    "Title ISBN Pub date Edn  Revised Date",
                    "1",
                    "Shetland – Yell, Unst and",
                    "Fetlar",
                    "9780319473245",
                    "24/02/16",
                    "Feb",
                    "2016",
                    "May 2015"
                });

            var sut = new OsFile(mockReader.Object, new OsFileParser());

            var actual = sut.LandrangerActiveMaps.First();

            Assert.That(actual.Publisher, Is.EqualTo(MapConstants.OrdnanceSurvey));
            Assert.That(actual.Series, Is.EqualTo(MapConstants.LandrangerActive));
            Assert.That(actual.Code, Is.EqualTo("1"));
            Assert.That(actual.Name, Is.EqualTo("Shetland – Yell, Unst and Fetlar"));
            Assert.That(actual.Isbn, Is.EqualTo("9780319473245"));
            Assert.That(actual.Scale, Is.EqualTo(MapConstants.OneTo50K));
        }

        [Test]
        public void CanParseExplorerSectionOfCatalogue()
        {
            var mockReader = new Mock<IOsFileReader>();
            mockReader
                .Setup(x => x.ReadLines())
                .Returns(new List<string>
                {
                    "3           OS Explorer current editions",
                    "(1:25 000 scale – 4 cm to 1 km or 2½ inches to 1 mile)",
                    "Price: £8.99",
                    "Note: All Explorer have been reprinted with a new Rebranded cover.",
                    "Revision date of the map data is listed in the Revised date column.",
                    "Explorer  Title ISBN",
                    "Pub",
                    "date",
                    "Edn Revised date",
                    "OL1 Peak District – Dark Peak area 9780319242407 10/06/15",
                    "May",
                    "2015 December 2010"
                });

            var sut = new OsFile(mockReader.Object, new OsFileParser());

            var actual = sut.ExplorerMaps.First();

            Assert.That(actual.Publisher, Is.EqualTo(MapConstants.OrdnanceSurvey));
            Assert.That(actual.Series, Is.EqualTo(MapConstants.Explorer));
            Assert.That(actual.Code, Is.EqualTo("OL1"));
            Assert.That(actual.Name, Is.EqualTo("Peak District – Dark Peak area"));
            Assert.That(actual.Isbn, Is.EqualTo("9780319242407"));
            Assert.That(actual.Scale, Is.EqualTo(MapConstants.OneTo25K));
        }

        [Test]
        public void CanParseExplorerActiveSectionOfCatalogue()
        {
            var mockReader = new Mock<IOsFileReader>();
            mockReader
                .Setup(x => x.ReadLines())
                .Returns(new List<string>
                {
                    "4           OS Explorer – Active current editions",
                    "(1:25 000 scale – 4 cm to 1 km or 2½ inches to 1 mile)",
                    "Price: £14.99",
                    "Note: All Explorer have been reprinted with a new Rebranded cover.",
                    "Revison date of the map data is listed in the Revised date column.",
                    "Explorer",
                    "Active",
                    "Title ISBN-13 Pub date Edn Revised Date",
                    "OL1 Peak District – Dark Peak area 9780319469194 10/06/15",
                    "May 2015 December 2010"
                });

            var sut = new OsFile(mockReader.Object, new OsFileParser());

            var actual = sut.ExplorerActiveMaps.First();

            Assert.That(actual.Publisher, Is.EqualTo(MapConstants.OrdnanceSurvey));
            Assert.That(actual.Series, Is.EqualTo(MapConstants.ExplorerActive));
            Assert.That(actual.Code, Is.EqualTo("OL1"));
            Assert.That(actual.Name, Is.EqualTo("Peak District – Dark Peak area"));
            Assert.That(actual.Isbn, Is.EqualTo("9780319469194"));
            Assert.That(actual.Scale, Is.EqualTo(MapConstants.OneTo25K));
        }

        [Test]
        public void CanParseDiscovererSectionOfCatalogue()
        {
            var mockReader = new Mock<IOsFileReader>();
            mockReader
                .Setup(x => x.ReadLines())
                .Returns(new List<string>
                {
                    "10   Irish Discoverer Map current editions",
                    "(1:50 000 scale – 2 cm to 1 km or 1¼ inches to 1 mile)",
                    "Price: £6.50 (maps available folded only)",
                    "Discoverer Title ISBN-13 Pub date Edn",
                    "4 Coleraine 9781905306640 11/04/12 E"
                });

            var sut = new OsFile(mockReader.Object, new OsFileParser());

            var actual = sut.DiscovererMaps.First();

            Assert.That(actual.Publisher, Is.EqualTo(MapConstants.OrdnanceSurvey));
            Assert.That(actual.Series, Is.EqualTo(MapConstants.Discoverer));
            Assert.That(actual.Code, Is.EqualTo("4"));
            Assert.That(actual.Name, Is.EqualTo("Coleraine"));
            Assert.That(actual.Isbn, Is.EqualTo("9781905306640"));
            Assert.That(actual.Scale, Is.EqualTo(MapConstants.OneTo50K));
        }

        [Test]
        public void CanParseDiscoverySectionOfCatalogue()
        {
            var mockReader = new Mock<IOsFileReader>();
            mockReader
                .Setup(x => x.ReadLines())
                .Returns(new List<string>
                {
                    "11   Irish Discovery Map current editions",
                    "(1:50 000 scale – 2 cm to 1 km or 1¼ inches to 1 mile)",
                    "Price: £8.25 (maps available folded only).",
                    "Discovery Title ISBN-13 Pub date Edn",
                    "1 Donegal (NW) 9781907122415 30/01/12 4th"
                });

            var sut = new OsFile(mockReader.Object, new OsFileParser());

            var actual = sut.DiscoveryMaps.First();

            Assert.That(actual.Publisher, Is.EqualTo(MapConstants.OrdnanceSurvey));
            Assert.That(actual.Series, Is.EqualTo(MapConstants.Discovery));
            Assert.That(actual.Code, Is.EqualTo("1"));
            Assert.That(actual.Name, Is.EqualTo("Donegal (NW)"));
            Assert.That(actual.Isbn, Is.EqualTo("9781907122415"));
            Assert.That(actual.Scale, Is.EqualTo(MapConstants.OneTo50K));
        }
    }
}
