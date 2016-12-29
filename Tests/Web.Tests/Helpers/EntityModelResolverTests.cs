using System.Linq;
using NUnit.Framework;
using ScotlandsMountains.Web.Server.Helpers;

namespace Web.Tests.Helpers
{
    [TestFixture]
    public class EntityModelResolverTests
    {
        private EntityModelResolver _sut;


        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _sut = new EntityModelResolver(new MockDomainRoot());
        }

        [Test]
        public void ThenListsAreResolved()
        {
            var actual = _sut.Lists(MockDomainRoot.EntityIds).Single();
            Assert.That(actual.Id, Is.EqualTo(MockDomainRoot.EntityId));
            Assert.That(actual.Name, Is.EqualTo(MockDomainRoot.EntityName));
        }

        [Test]
        public void ThenSectionIsResolved()
        {
            var actual = _sut.Section(MockDomainRoot.EntityId);
            Assert.That(actual.Id, Is.EqualTo(MockDomainRoot.EntityId));
            Assert.That(actual.Name, Is.EqualTo(MockDomainRoot.EntityName));
        }

        [Test]
        public void ThenMapsAreResolved()
        {
            var actual = _sut.Maps(MockDomainRoot.EntityIds).Single();
            Assert.That(actual.Id, Is.EqualTo(MockDomainRoot.EntityId));
            Assert.That(actual.Name, Is.EqualTo(MockDomainRoot.EntityName));
        }

        [Test]
        public void ThenCountryIsResolved()
        {
            var actual = _sut.Country(MockDomainRoot.EntityId);
            Assert.That(actual.Id, Is.EqualTo(MockDomainRoot.EntityId));
            Assert.That(actual.Name, Is.EqualTo(MockDomainRoot.EntityName));
        }
    }
}
