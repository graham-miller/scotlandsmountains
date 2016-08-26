using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using ScotlandsMountains.Import;
using ScotlandsMountains.Import.Dobih;

namespace ScotlandsMountains.ImportTests
{
    [TestFixture]
    public class CountryFactoryTests
    {
        [TestCase("S", "Scotland")]
        [TestCase("E", "England")]
        [TestCase("W", "Wales")]
        [TestCase("I", "Ireland")]
        [TestCase("M", "Isle of Man")]
        [TestCase("C", "Channel Islands")]
        public void WhenBuildingThenCountryConstructedCorrectly(string countryCode, string expectedName)
        {
            const string id = "ID";

            var mockIdGenerator = new Mock<IIdGenerator>();
            mockIdGenerator.Setup(x => x.Generate()).Returns(id);

            var mockDobihRecord = new Mock<IDobihRecord>();
            mockDobihRecord.Setup(x => x.Country).Returns(countryCode);

            var mockDobihFile = new Mock<IDobihFile>();
            mockDobihFile.Setup(x => x.Records).Returns(new List<IDobihRecord> {mockDobihRecord.Object});

            var sut = new CountryFactory(mockIdGenerator.Object);

            var actual = sut.BuildFrom(mockDobihFile.Object);

            Assert.That(actual.Single().Id, Is.EqualTo(id));
            Assert.That(actual.Single().Name, Is.EqualTo(expectedName));
        }
    }
}
