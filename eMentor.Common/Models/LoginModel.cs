using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eMentor.Common.Models
{ 
    public class LoginModel
    {
        [JsonProperty(PropertyName ="userName")]
        public string UserName { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "phone")]
        public string Phone { get; set; }

        [JsonProperty(PropertyName = "passCode")]
        public string PassCode { get; set; }
    }
}
