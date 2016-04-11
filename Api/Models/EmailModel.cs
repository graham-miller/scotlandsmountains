using System.ComponentModel.DataAnnotations;
using ScotlandsMountains.Api.Validations;

namespace ScotlandsMountains.Api.Models
{
    public class EmailModel
    {
        [Required(ErrorMessage = "Email address is required")]
        [EmailAddressValidation(ErrorMessage = "Invalid email address")]
        public string From { get; set; }

        [Required(ErrorMessage = "A subject is required")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "A message is required")]
        public string Message { get; set; }
    }
}