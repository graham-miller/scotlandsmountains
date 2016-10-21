using NUnit.Framework;
using ScotlandsMountains.Domain;
using ScotlandsMountains.Web.Server.Models;

namespace Web.Tests.Models
{
    [TestFixture]
    public class EntityModelTests
    {
        private EntityModel _actual;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var entity = new EntityShim
            {
                Id = MockDomainRoot.EntityId,
                Name = MockDomainRoot.EntityName
            };

            _actual = new EntityModel(entity);
        }

        [Test]
        public void AssertIdMappedCorrectly()
        {
            Assert.That(_actual.Id, Is.EqualTo(MockDomainRoot.EntityId));
        }

        [Test]
        public void AssertNameMappedCorrectly()
        {
            Assert.That(_actual.Name, Is.EqualTo(MockDomainRoot.EntityName));
        }

        class EntityShim : Entity { }
    }
}
