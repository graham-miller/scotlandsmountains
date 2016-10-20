using NUnit.Framework;
using ScotlandsMountains.Domain;
using ScotlandsMountains.Web.Server.Models;

namespace Web.Tests.Models
{
    [TestFixture]
    public class EntityModelTests
    {
        private const string EntityId = "EntityId";
        private const string EntityName = "EntityName";

        private EntityModel _actual;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var entity = new EntityShim
            {
                Id = EntityId,
                Name = EntityName
            };

            _actual = new EntityModel(entity);
        }

        [Test]
        public void AssertIdMappedCorrectly()
        {
            Assert.That(_actual.Id, Is.EqualTo(EntityId));
        }

        [Test]
        public void AssertNameMappedCorrectly()
        {
            Assert.That(_actual.Name, Is.EqualTo(EntityName));
        }

        class EntityShim : Entity { }
    }
}
