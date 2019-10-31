using eMentor.Entities.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;
using static eMentor.Common.Utils.UtilEnum;

namespace eMentor.Entities.Entities
{
    public class Course: BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsAvailable { get; set; }
        public CourseType CourseType { get; set; }

        public int OwnerId { get; set; }
        [ForeignKey("OwnerId")]
        public virtual User Owner { get; set; }
    }
}
