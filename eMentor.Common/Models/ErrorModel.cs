using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eMentor.Common.Models
{ 
    public class ErrorModel
    {
        [JsonProperty(PropertyName ="code")]
        public string Code { get; set; }

        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

        [JsonProperty(PropertyName = "innerError")]
        public string InnerError { get; set; }
    }

    public class ApiErrorModel
    {
        public ApiErrorModel()
        {
            Error = new ErrorModel();
        }
        [JsonProperty(PropertyName = "error")]
        public ErrorModel Error { get; set; }
    }
}
