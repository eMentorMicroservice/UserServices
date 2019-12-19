using eMentor.Entities.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using static eMentor.Common.Utils.UtilEnum;

namespace eMentor.Entities.Entities
{
    public class Course: BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime AvailableFrom { get; set; }
        public DateTime AvailableTo { get; set; }
        public CourseType CourseCategory { get; set; }
        public string CourseImage { get; set; }

        public int OwnerId { get; set; }
        [ForeignKey("OwnerId")]
        public virtual User Owner { get; set; }
        public virtual double CourseFee { get; set; }
    }
}
