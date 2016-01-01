using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NHibernate;
using Newtonsoft.Json;
using ScotlandsMountains.Domain.Entities;
using ScotlandsMountains.Web.Helpers;
using ScotlandsMountains.Web.Models;

namespace Web.Controllers
{
    public class MountainsController : ApiController
    {
        private readonly ISession _session;

        public MountainsController(ISession session)
        {
            _session = session;
        }

        [HttpGet]
        public JsonNetResult Search(string term)
        {
            // Ref.: http://nhforge.org/blogs/nhibernate/archive/2009/12/17/queryover-in-nh-3-0.aspx
            var data = _session.QueryOver<Mountain>()
                    .WhereRestrictionOn(x => x.Name).IsInsensitiveLike("%" + term + "%")
                    .OrderBy(x => x.Height.Feet).Desc
                    .List()
                    .Select(x => new MountainModel(x));

            return new JsonNetResult { Formatting = Formatting.Indented, Data = data };
        }

        [HttpGet]
        public JsonNetResult Munros()
        {
            return List("Munro");
        }

        [HttpGet]
        public JsonNetResult Corbetts()
        {
            return List("Corbett");
        }

        [HttpGet]
        public JsonNetResult Grahams()
        {
            return List("Graham");
        }

        private JsonNetResult List(string name)
        {
            var data = _session.QueryOver<Table>()
                               .WhereRestrictionOn(x => x.Name).IsInsensitiveLike(name)
                               .Fetch(x => x.Mountains).Eager
                               .SingleOrDefault()
                               .Mountains
                               .OrderByDescending(x => x.Height.Feet)
                               .Select(x => new MountainModel(x))
                               .ToList();

            return new JsonNetResult { Formatting = Formatting.Indented, Data = data };
        }

        public JsonNetResult Get(int id)
        {
            var data = new MountainModel(_session.Get<Mountain>(id));
            return new JsonNetResult { Formatting = Formatting.Indented, Data = data };
        }
    }
}