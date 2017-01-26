using System.ComponentModel.DataAnnotations;

namespace ScotlandsMountains.Web.Server.Models
{
    public class ContactUsModel
    {
        public bool Sent { get; set; }
    
        public bool Error { get; set; }

        [Required(ErrorMessage = "Required")]
        [EmailAddress(ErrorMessage = "Invalid")]
        public string Sender { get; set; }

        [Required(ErrorMessage = "Required")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Required")]
        public string Message { get; set; }

        public string SenderErrorText { get; set; }

        public string SubjectErrorText { get; set; }

        public string MessageErrorText { get; set; }
    }
}
