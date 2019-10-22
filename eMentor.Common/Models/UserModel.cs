using eMentor.Common.Utils;
using eMentor.Entities.Entities;
using Newtonsoft.Json;
using System;
using static eMentor.Common.Utils.UtilEnum;

namespace eMentor.Common.Models
{
    public class UserApiModel
    {
        public UserApiModel() {   }
        [JsonProperty(PropertyName = "userid")]
        public int UserId { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "fullname")]
        public string FullName { get; set; }

        [JsonProperty(PropertyName = "username")]
        public string UserName { get; set; }

        [JsonProperty(PropertyName= "password")]
        public string PassWord { get; set; }
    }

    public class UserModel
    {
        public UserModel()
        {
            GenderModel = new HardcodeModel();
            RoleModel = new HardcodeModel();
        }
        [JsonProperty(PropertyName = "userid")]
        public int UserId { get; set; }

        [JsonProperty(PropertyName = "avatar")]
        public string Avatar { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "fullname")]
        public string FullName { get; set; }


        [JsonProperty(PropertyName = "gender")]
        public Gender Gender { get; set; }

        public HardcodeModel GenderModel { get; set; }


        [JsonProperty(PropertyName = "role")]
        public UserRole Role { get; set; }

        public HardcodeModel RoleModel { get; set; }

        [JsonProperty(PropertyName = "phone")]
        public string Phone { get;  set; }
    }

    public class UserIdModel
    {
        public int UserId { get; set; }
        public bool IsDeactivate { get; set; }
    }
    public static class UserModelEmm
    {
        public static User ToEntity(this UserApiModel model, User entity)
        {
            if (entity == null)
                entity = new User();

            entity.PassCode = model.PassWord;
            entity.Email = model.Email;
            entity.FullName = model.FullName;
            entity.Id = model.UserId;

            return entity;
        }

        public static UserModel ToUserModel(this User user, UserRole role, bool isSelfProfile)
        {
            var model = new UserModel();

            if (user != null)
            {
                model.UserId = user.Id;
                model.Avatar = UtilCommon.GetDisplayImageUrl(user.Avatar);
                model.FullName = user.FullName;
                model.Email = user.Email;
                model.Phone = user.Phone;
                model.Gender = user.Gender;
            }

            return model;
        }
    }
}
