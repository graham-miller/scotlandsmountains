using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using ScotlandsMountains.Web.Server.Helpers;

namespace Web.Tests.Helpers
{
    [TestFixture]
    public class EntityModelResolverTests
    {
        private EntityModelResolver _sut;

        private const string EntityId = "EntityId";
        private const string EntityName = "EntityName";

        private static readonly IList<string> EntityIds = new List<string> {EntityId};

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var mockDomainRoot = TestUtilities.GetMockDomainRoot(EntityId, EntityName);
            _sut = new EntityModelResolver(mockDomainRoot.Object);
        }

        [Test]
        public void ThenClassificationsAreResolved()
        {
            var actual = _sut.Classifications(EntityIds).Single();
            Assert.That(actual.Id, Is.EqualTo(EntityId));
            Assert.That(actual.Name, Is.EqualTo(EntityName));
        }

        [Test]
        public void ThenSectionIsResolved()
        {
            var actual = _sut.Section(EntityId);
            Assert.That(actual.Id, Is.EqualTo(EntityId));
            Assert.That(actual.Name, Is.EqualTo(EntityName));
        }

        [Test]
        public void ThenMapsAreResolved()
        {
            var actual = _sut.Maps(EntityIds).Single();
            Assert.That(actual.Id, Is.EqualTo(EntityId));
            Assert.That(actual.Name, Is.EqualTo(EntityName));
        }

        [Test]
        public void ThenCountryIsResolved()
        {
            var actual = _sut.Country(EntityId);
            Assert.That(actual.Id, Is.EqualTo(EntityId));
            Assert.That(actual.Name, Is.EqualTo(EntityName));
        }
    }
}
