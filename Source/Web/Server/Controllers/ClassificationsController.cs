using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ScotlandsMountains.Domain;
using ScotlandsMountains.Web.Server.Models;
using Humanizer;

namespace ScotlandsMountains.Web.Server.Controllers
{
    [Route("api/[controller]")]
    public class ClassificationsController : EntitiesController<Classification>
    {
        public ClassificationsController(IDomainRoot domainRoot) : base(domainRoot, x => x.Classifications) { }

        [HttpGet("mountains/{classificationName}")]
        public IActionResult GetMountains(string classificationName)
        {
            Func<Classification, bool> isMatch = x => x.Name.Equals(classificationName.Singularize(), StringComparison.InvariantCultureIgnoreCase);
            var classification = DomainRoot.Classifications.Single(isMatch);

            if (classification == null)
                return NotFound();

            var mountains = DomainRoot.Mountains
                .Where(x => x.ClassificationIds.Contains(classification.Id))
                .OrderByDescending(x => x.Height)
                .Select(x => new MountainSummaryModel(x));

            return new ObjectResult(mountains);
        }
    }
}