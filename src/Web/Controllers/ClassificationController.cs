using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using NHibernate;
using ScotlandsMountains.Domain;
using ScotlandsMountains.Web.Models;

namespace ScotlandsMountains.Web.Controllers
{
    [RoutePrefix("api/Classification")]
    [Route("{action}")]
    public class ClassificationController : ApiController
    {
        private readonly ISessionFactory _sessionFactory;

        public ClassificationController(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        [Route]
        public IEnumerable<ClassificationModel> Get()
        {
            return
                _sessionFactory.OpenStatelessSession()
                    .QueryOver<Classification>()
                    .OrderBy(x => x.Name).Asc
                    .List<Classification>()
                    .Select(x => new ClassificationModel(x));
        }

        public string Get(int id)
        {
            return "value";
        }
    }
}
