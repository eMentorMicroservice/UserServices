using eMentor.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
namespace eMentor.Common.Models
{
    public class HardcodeModel
    {
        public  HardcodeModel() { }

        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "Value")]
        public int Value { get; set; }
    }
    public static class HardcodeModelEmm
    {
        public static HardcodeModel ToModel(this HardCode hardCode)
        {
            var model = new HardcodeModel()
            {
                Name = hardCode.Name,
                Value = hardCode.Value
            };
            return model;
        }
        public static List<HardcodeModel> ToListModel(this IList<HardCode> hardCodes)
        {
            var models = new List<HardcodeModel>();
            if(hardCodes != null)
            {
                hardCodes.ToList().ForEach(p => models.Add(p.ToModel()));
            }
            return models;
        }
    }

}
