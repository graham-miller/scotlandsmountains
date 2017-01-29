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
        public void GivenEsThenReturnsScotland()
        {
            var actual = _sut.GetByDobihId("ES");
            Assert.That(actual.Id, Is.EqualTo(Id));
            Assert.That(actual.Name, Is.EqualTo("Scotland"));
        }
    }
}
