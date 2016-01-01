using System.Linq;
using System.Web.Http;
using NHibernate;
using Newtonsoft.Json;
using ScotlandsMountains.Domain.Entities;
using ScotlandsMountains.Web.Helpers;
using ScotlandsMountains.Web.Models;

namespace ScotlandsMountains.Web.Controllers
{
    public class MountainsController : ApiController
    {
        private static JsonNetResult _munros = null;
        private static JsonNetResult _corbetts = null;
        private static JsonNetResult _grahams = null;

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
                    .Take(50)
                    .List()
                    .Select(x => new MountainModel(x));

            return new JsonNetResult { Formatting = Formatting.Indented, Data = data };
        }

        [HttpGet]
        public JsonNetResult Munros()
        {
            return _munros ?? (_munros = List("Munro"));
        }

        [HttpGet]
        public JsonNetResult Corbetts()
        {
            return _corbetts ?? (_corbetts = List("Corbett"));
        }

        [HttpGet]
        public JsonNetResult Grahams()
        {
            return _grahams ?? (_grahams = List("Graham"));
        }

        private JsonNetResult List(string name)
        {
            var data = _session.QueryOver<Table>()
                               .Where(x => x.Name == name)
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