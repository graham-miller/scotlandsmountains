using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScotlandsMountains.Web.Server.Models
{
    public class ContactUsModel
    {
        public string Sender { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}
