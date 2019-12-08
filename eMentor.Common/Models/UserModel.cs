using eMentor.Common.Utils;
using eMentor.Entities.Entities;
using Newtonsoft.Json;
using System;
using static eMentor.Common.Utils.UtilEnum;

namespace eMentor.Common.Models
{
    public class UserApiModel
    {
        public UserApiModel() 
        {   
        }
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

        [JsonProperty(PropertyName = "dateofbirth")]
        public string DateOfBirth { get; set; }

        [JsonProperty(PropertyName = "linkedsite")]
        public string LinkedSite { get; set; }

        [JsonProperty(PropertyName = "address")]
        public string Address { get; set; }
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

        public static UserModel ToUserModel(this User user, UserRole role)
        {
            var model = new UserModel();

            if (user != null)
            {
                model.UserId = user.Id;
                model.Avatar = UtilCommon.GetDisplayImageUrl(user.Avatar);
                model.FullName = user.FullName;
                model.Email = user.Email;
                model.Phone = user.Phone;
                model.Role = user.Role;
                model.Gender = user.Gender;
                model.LinkedSite = user.LinkedSite;
                model.Address = user.Address;
                if (string.IsNullOrWhiteSpace(user.DateOfBirth.ToString()))
                    model.DateOfBirth = Constants.DEFAULT_DATEOFBIRTH;
                else
                    model.DateOfBirth = user.DateOfBirth.ToString();
            }

            return model;
        }
    }
}
