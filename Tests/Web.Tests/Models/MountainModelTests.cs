using NUnit.Framework;
using ScotlandsMountains.Domain;
using ScotlandsMountains.Web.Server.Models;

namespace Web.Tests.Models
{
    [TestFixture]
    public class MountainModelTests
    {
        private MountainModel _sut;

        private const string EntityId = "EntityId";
        private const string EntityName = "EntityName";

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var mockDomainRoot = TestUtilities.GetMockDomainRoot(EntityId, EntityName);

            var mountain = new Mountain();

            _sut = new MountainModel(mountain, mockDomainRoot.Object);
        }

        //[Test]
        //public void ThenClassificationsAreResolved()
        //{
        //    var actual = _sut.Classifications(EntityIds).Single();
        //    Assert.That(actual.Id, Is.EqualTo(EntityId));
        //    Assert.That(actual.Name, Is.EqualTo(EntityName));
        //}

        //[Test]
        //public void ThenSectionIsResolved()
        //{
        //    var actual = _sut.Section(EntityId);
        //    Assert.That(actual.Id, Is.EqualTo(EntityId));
        //    Assert.That(actual.Name, Is.EqualTo(EntityName));
        //}

        //[Test]
        //public void ThenMapsAreResolved()
        //{
        //    var actual = _sut.Maps(EntityIds).Single();
        //    Assert.That(actual.Id, Is.EqualTo(EntityId));
        //    Assert.That(actual.Name, Is.EqualTo(EntityName));
        //}

        //[Test]
        //public void ThenCountryIsResolved()
        //{
        //    var actual = _sut.Country(EntityId);
        //    Assert.That(actual.Id, Is.EqualTo(EntityId));
        //    Assert.That(actual.Name, Is.EqualTo(EntityName));
        //}
    }
}
