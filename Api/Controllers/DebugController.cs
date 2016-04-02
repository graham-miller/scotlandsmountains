using System.Web.Http;

namespace ScotlandsMountains.Api.Controllers
{
    public class DebugController : ApiController
    {
        [HttpGet, Route("api/debug")]
        public dynamic Get()
        {
            return new
            {
                version = "1.0.0"
            };
        }
    }
}
