using eMentor.Entities.Entities.Base;
using static eMentor.Common.Utils.UtilEnum;

namespace eMentor.Entities.Entities
{
    public class User: BaseEntity
    {
        public string UserName { get; set; }
        public string PassCode { get; set; }
        public string Salt { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool IsFirstLogin { get; set; }
        public UserRole Role { get; set; }
        public bool IsHardCode { get; set; }
        public string FullName { get; set; }
        public Gender Gender { get; set; }
        public string Avatar { get; set; }
    }
}
