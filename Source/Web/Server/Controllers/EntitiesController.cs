using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ScotlandsMountains.Domain;

namespace ScotlandsMountains.Web.Server.Controllers
{
    public abstract class EntitiesController<T> : DomainRootController where T : Entity
    {
        private readonly Func<IDomainRoot, IEnumerable<T>> _entitiesFunc;

        protected EntitiesController(IDomainRoot domainRoot, Func<IDomainRoot,IEnumerable<T>> entitiesFunc) : base(domainRoot)
        {
            _entitiesFunc = entitiesFunc;
        }

        [HttpGet()]
        public IActionResult Get()
        {
            return new ObjectResult(_entitiesFunc(DomainRoot));
        }

        [HttpGet("{id}")]
        public virtual IActionResult Get(string id)
        {
            var country = _entitiesFunc(DomainRoot).GetById(id);

            if (country == null)
                return NotFound();

            return new ObjectResult(country);
        }
    }

    [Route("api/[controller]")]
    public class MapsController : EntitiesController<Map>
    {
        public MapsController(IDomainRoot domainRoot) : base(domainRoot, x => x.Maps) { }
    }

    [Route("api/[controller]")]
    public class SectionsController : EntitiesController<Section>
    {
        public SectionsController(IDomainRoot domainRoot) : base(domainRoot, x => x.Sections) { }
    }
}
