using static eMentor.Common.Utils.UtilEnum;

namespace eMentor.Common.ApiModels
{
    public class LoginApiModel
    {
        public string Token { get; set; }

        public bool IsFirstLogin { get; set; }

        public string FullName { get; set; }

        public string Avatar { get; set; }
        public int UserId { get; set; }
        public UserRole Role { get; set; }
    }

}
