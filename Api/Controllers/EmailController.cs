using System;
using System.Web.Http;
using ScotlandsMountains.Api.Models;

namespace ScotlandsMountains.Api.Controllers
{
    public class EmailController : ApiController
    {
        [HttpPost, Route("api/emails")]
        public IHttpActionResult SendEmail(EmailModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {

            }
            catch (Exception)
            {
                return InternalServerError();
            }

            return Ok();
        }
    }
}
