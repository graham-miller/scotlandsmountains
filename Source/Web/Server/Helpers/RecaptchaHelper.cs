using Microsoft.Extensions.Options;
using RestSharp;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ScotlandsMountains.Web.Server.Helpers
{
    public interface IRecaptchaHelper
    {
        Task<bool> IsValidAsync(string recaptchaResponse);
    }

    public class RecaptchaHelper : IRecaptchaHelper
    {
        private readonly Configuration _configuration;

        public RecaptchaHelper(IOptions<Configuration> configuration)
        {
            _configuration = configuration.Value;
        }

        public async Task<bool> IsValidAsync(string recaptchaResponse)
        {
            using (var client = new HttpClient())
            {
                var url =
                    @"https://www.google.com/recaptcha/api/siteverify?" +
                    $"secret={_configuration.Recaptcha.SecretKey}&" +
                    $"response={recaptchaResponse}";

                var response = await client.GetAsync(url);

                if (!response.IsSuccessStatusCode) return false;

                var json = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ReCaptcha>(json);

                return result.Success;
            }
        }

        class ReCaptcha
        {

            [JsonProperty("success")]
            public bool Success { get; set; }

            [JsonProperty("error-codes")]
            public List<string> ErrorCodes { get; set; }
        }
    }
}
