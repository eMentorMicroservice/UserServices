using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static eMentor.Common.Utils.UtilEnum;

namespace eMentor.Common.Models
{
    public class UserTokenModel
    {
        public int UserId { get; set; }
        public UserRole UserRole { get; set; }
        public string FullName { get; set; }
    }
}
