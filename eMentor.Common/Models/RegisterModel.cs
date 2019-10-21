using Newtonsoft.Json;

namespace eMentor.Common.Models
{
    public class RegisterModel
    {
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }

        [JsonProperty(PropertyName = "confirmpassword")]
        public string ConfirmPassword { get; set; }
    }
}
