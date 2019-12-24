using eMentor.Entities.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace eMentor.Entities.Entities
{
    public class UserExperience: BaseEntity
    {
        public string JobTitle { get; set; }
        public string CompanySite { get; set; }
        public string Description { get; set; }
        public string Time { get; set; }
        public int MentorId { get; set; }
        [ForeignKey("MentorId")]
        public virtual User Mentor { get; set; }
    }
}
