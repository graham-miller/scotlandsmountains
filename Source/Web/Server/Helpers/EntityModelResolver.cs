using System.Linq;
using System.Collections.Generic;
using ScotlandsMountains.Web.Server.Models;
using ScotlandsMountains.Domain;

namespace ScotlandsMountains.Web.Server.Helpers
{
    public class EntityModelResolver
    {
        public EntityModelResolver(IDomainRoot domainRoot)
        {
            _domainRoot = domainRoot;
        }

        public IList<EntityModel> Classifications(IList<string> classificationIds)
        {
            return classificationIds
                .Select(id => _domainRoot.Classifications.Single(x => x.Id == id))
                .Select(x => new EntityModel(x))
                .OrderBy(x => x.Name)
                .ToList();
        }

        public IList<EntityModel> Maps(IList<string> mapIds)
        {
            return mapIds
                .Select(id => _domainRoot.Maps.GetById(id))
                .Select(x => new EntityModel(x))
                .OrderBy(x => x.Name)
                .ToList();
        }

        public EntityModel Section(string sectionId)
        {
            return new EntityModel(_domainRoot.Sections.Single(x => x.Id == sectionId));
        }

        public EntityModel Country(string countryId)
        {
            // TODO should be Single not First, but we've got two!?
            return new EntityModel(_domainRoot.Countries.First(x => x.Id == countryId));
        }

        private readonly IDomainRoot _domainRoot;
    }
}
