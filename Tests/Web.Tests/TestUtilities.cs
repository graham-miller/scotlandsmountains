using System.Collections.Generic;
using Moq;
using ScotlandsMountains.Domain;

namespace Web.Tests
{
    public static class TestUtilities
    {
        public static Mock<IDomainRoot> GetMockDomainRoot(string EntityId, string EntityName)
        {
            var mockMaps = new Mock<Maps>();
            mockMaps
                .Setup(x => x.GetById(EntityId))
                .Returns(new Map { Id = EntityId, Name = EntityName });

            var mockDomainRoot = new Mock<IDomainRoot>();

            mockDomainRoot
                .Setup(x => x.Classifications)
                .Returns(GetMockEntities<Classification>(EntityId, EntityName));

            mockDomainRoot
                .Setup(x => x.Sections)
                .Returns(GetMockEntities<Section>(EntityId, EntityName));

            mockDomainRoot
                .Setup(x => x.Maps)
                .Returns(mockMaps.Object);

            mockDomainRoot
                .Setup(x => x.Countries)
                .Returns(GetMockEntities<Country>(EntityId, EntityName));

            return mockDomainRoot;
        }

        private static IList<T> GetMockEntities<T>(string EntityId, string EntityName) where T : Entity, new()
        {
            var entity = new T { Id = EntityId, Name = EntityName };
            return new List<T> { entity };
        }
    }
}
