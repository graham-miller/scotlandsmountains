using ScotlandsMountains.Api.Models;
using ScotlandsMountains.Domain.Abstractions;
using ScotlandsMountains.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ScotlandsMountains.Api.Controllers
{
    public class MountainController : ApiController
    {
        public MountainController(IDomainRoot domainRoot)
        {
            _mountains = domainRoot.Mountains;
        }

        [HttpGet, Route("api/mountain/{key}")]
        public MountainSummary GetByKey(string key)
        {
            return MountainSummary.Create(_mountains.SingleOrDefault(x => x.Key == key));
        }

        [HttpGet, Route("api/search/{term}")]
        public IEnumerable<MountainSummary> GetByName(string term)
        {
            return _mountains
                .Where(x => x.Name.IndexOf(term, StringComparison.OrdinalIgnoreCase) >= 0)
                .OrderByDescending(x => x.Height.Metres)
                .Take(50)
                .Select(MountainSummary.Create);
        }

        [HttpGet, Route("api/classification/{classification}/mountains")]
        public IEnumerable<MountainSummary> GetByClassification(string classification)
        {
            return _mountains
                .Where(x => x.Classifications.Any(y => string.Equals(y.Name, classification, StringComparison.OrdinalIgnoreCase)))
                .OrderByDescending(x => x.Height.Metres)
                .Select(MountainSummary.Create)
                .ToArray();
        }

        private IEnumerable<Mountain> _mountains;
    }
}
