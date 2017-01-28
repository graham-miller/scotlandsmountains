using System.ComponentModel.DataAnnotations;

namespace ScotlandsMountains.Web.Server.Models
{
    public class ContactUsModel
    {
        [Required(ErrorMessage = "Required")]
        [EmailAddress(ErrorMessage = "Invalid")]
        public string Sender { get; set; }

        [Required(ErrorMessage = "Required")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Required")]
        public string Message { get; set; }
    }
}
