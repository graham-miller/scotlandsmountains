using System.Collections.Generic;
using ScotlandsMountains.Domain;

namespace Web.Tests
{
    public class MockDomainRoot : IDomainRoot
    {
        public const string EntityId = "EntityId";
        public const string EntityName = "EntityName";
        public static readonly IList<string> EntityIds = new List<string> { EntityId };

        public MockDomainRoot()
        {
            SetUp();
        }

        public IList<List> Lists { get; private set; }
        public IList<Section> Sections { get; private set; }
        public Maps Maps { get; private set; }
        public IList<Mountain> Mountains { get; private set; }
        public IList<Country> Countries { get; private set; }


        private void SetUp()
        {
            Lists = GetMockEntities<List>();
            Sections = GetMockEntities<Section>();
            Countries = GetMockEntities<Country>();

            Maps = new Maps
            {
                Landranger = GetMockEntities<Map>(),
                LandrangerActive = new List<Map>(),
                Explorer = new List<Map>(),
                ExplorerActive = new List<Map>(),
                Discoverer = new List<Map>(),
                Discovery = new List<Map>()
            };
        }

        private static IList<T> GetMockEntities<T>() where T : Entity, new()
        {
            var entity = new T { Id = EntityId, Name = EntityName };
            return new List<T> { entity };
        }
    }
}
