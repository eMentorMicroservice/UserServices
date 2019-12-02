using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eMentor.Common.Models
{
    public class ChangePasscodeModel
    {
        [Required]
        [JsonProperty(PropertyName = "oldPasscode")]
        public string OldPasscode { get; set; }

        [Required]
        [JsonProperty(PropertyName = "newPasscode")]
        public string NewPasscode { get; set; }
    }
}
