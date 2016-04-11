using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace ScotlandsMountains.Api.Validations
{
    public class EmailAddressValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var attempted = value.ToString();

            try
            {
                new MailAddress(attempted);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}