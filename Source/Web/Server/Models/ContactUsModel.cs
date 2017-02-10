using System.ComponentModel.DataAnnotations;

namespace ScotlandsMountains.Web.Server.Models
{
    public class ContactUsModel
    {
        [Required]
        [EmailAddress]
        public string Sender { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string Message { get; set; }

        [Required]
        public string GRecaptchaResponse { get; set; }
    }
}
