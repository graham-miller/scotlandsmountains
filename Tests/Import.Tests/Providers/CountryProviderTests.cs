using Moq;
using NUnit.Framework;
using ScotlandsMountains.Import.Providers;

namespace ScotlandsMountains.Import.Tests.Providers
{
    [TestFixture]
    public class CountryProviderTests
    {
        private const string Id = "Id";
        private CountryProvider _sut;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var mockIdGenerator = new Mock<IIdGenerator>();
            mockIdGenerator.Setup(x => x.Generate()).Returns(Id);

            _sut = new CountryProvider(mockIdGenerator.Object);
        }

        [Test]
        public void GivenSThenReturnsScotland()
        {
            var actual = _sut.GetByDobihId("S");
            Assert.That(actual.Id, Is.EqualTo(Id));
            Assert.That(actual.Name, Is.EqualTo("Scotland"));
        }

        [Test]
        public void GivenSeThenReturnsScotland()
        {
            var actual = _sut.GetByDobihId("S");
            Assert.That(actual.Id, Is.EqualTo(Id));
            Assert.That(actual.Name, Is.EqualTo("Scotland"));
        }

        [Test]
        public void GivenEThenReturnsEngland()
        {
            var actual = _sut.GetByDobihId("E");
            Assert.That(actual.Id, Is.EqualTo(Id));
            Assert.That(actual.Name, Is.EqualTo("England"));
        }

        [Test]
        public void GivenWThenReturnsWales()
        {
            var actual = _sut.GetByDobihId("W");
            Assert.That(actual.Id, Is.EqualTo(Id));
            Assert.That(actual.Name, Is.EqualTo("Wales"));
        }

        [Test]
        public void GivenIThenReturnsIreland()
        {
            var actual = _sut.GetByDobihId("I");
            Assert.That(actual.Id, Is.EqualTo(Id));
            Assert.That(actual.Name, Is.EqualTo("Ireland"));
        }

        [Test]
        public void GivenCThenReturnsChannelIslands()
        {
            var actual = _sut.GetByDobihId("C");
            Assert.That(actual.Id, Is.EqualTo(Id));
            Assert.That(actual.Name, Is.EqualTo("Channel Islands"));
        }

        [Test]
        public void GivenMThenReturnsIsleOfMan()
        {
            var actual = _sut.GetByDobihId("M");
            Assert.That(actual.Id, Is.EqualTo(Id));
            Assert.That(actual.Name, Is.EqualTo("Isle of Man"));
        }

        [Test]
        public void ThenCountryCountIsCorrect()
        {
            Assert.That(_sut.GetAll().Count, Is.EqualTo(7));
        }
    }
}
