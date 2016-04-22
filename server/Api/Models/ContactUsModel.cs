using System.ComponentModel.DataAnnotations;

namespace ScotlandsMountains.Api.Models
{
    public class ContactUsModel
    {
        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string From { get; set; }

        [Required(ErrorMessage = "A subject is required")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "A message is required")]
        public string Text { get; set; }
    }
}