using eMentor.Common.Utils;
using eMentor.Entities.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using static eMentor.Common.Utils.UtilEnum;

namespace eMentor.Common.Models
{
    public class UserApiModel
    {
        public UserApiModel() 
        {
            Exp = new List<UserExperience>();
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

        [JsonProperty(PropertyName = "phone")]
        public string Phone { get; set; }

        [JsonProperty(PropertyName = "avatar")]
        public string Avatar { get; set; }

        [JsonProperty(PropertyName = "gender")]
        public Gender Gender { get; set; }

        [JsonProperty(PropertyName = "dateofbirth")]
        public string DateOfBirth { get; set; }

        [JsonProperty(PropertyName = "linkedsite")]
        public string LinkedSite { get; set; }

        [JsonProperty(PropertyName = "address")]
        public string Address { get; set; }
        public string Bio { get; set; }
        public string Location { get; set; }
        public string Strength { get; set; }
        public string Languages { get; set; }
        public IList<UserExperience> Exp { get; set; }
    }

    public class UserModel
    {
        public UserModel()
        {
            GenderModel = new HardcodeModel();
            RoleModel = new HardcodeModel();
            Exp = new List<UserExperience>();
        }
        [JsonProperty(PropertyName = "userId")]
        public int UserId { get; set; }

        [JsonProperty(PropertyName = "avatar")]
        public string Avatar { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "fullName")]
        public string FullName { get; set; }


        [JsonProperty(PropertyName = "gender")]
        public Gender Gender { get; set; }

        public HardcodeModel GenderModel { get; set; }


        [JsonProperty(PropertyName = "role")]
        public UserRole Role { get; set; }

        public HardcodeModel RoleModel { get; set; }

        [JsonProperty(PropertyName = "phone")]
        public string Phone { get;  set; }

        [JsonProperty(PropertyName = "dateOfBirth")]
        public string DateOfBirth { get; set; }

        [JsonProperty(PropertyName = "linkedSite")]
        public string LinkedSite { get; set; }

        [JsonProperty(PropertyName = "address")]
        public string Address { get; set; }
        public string Bio { get; set; }
        public string Location { get; set; }
        public string Strength { get; set; }
        public string Languages { get; set; }
        public IList<UserExperience> Exp { get; set; }
        public string UserName { get; set; }
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

            entity.Email = model.Email;
            entity.FullName = model.FullName;
            entity.LinkedSite = model.LinkedSite;
            entity.Address = model.Address;
            entity.Phone = model.Phone;
            entity.Gender = model.Gender;
            entity.DateOfBirth = UtilCommon.ConvertDateTime(model.DateOfBirth, Constants.DATETIME_FORMAT);
            entity.Id = model.UserId;
            entity.Bio = model.Bio;
            entity.Location = model.Location;
            entity.Strength = model.Strength;
            entity.Languages = model.Languages;
            entity.UserName = model.UserName;
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
                model.Bio = user.Bio;
                model.Location = user.Location;
                model.Strength = user.Strength;
                model.Languages = user.Languages;
                model.UserName = user.UserName;
                model.Exp = user.Exp;
                if (string.IsNullOrWhiteSpace(user.DateOfBirth.ToString()))
                    model.DateOfBirth = Constants.DEFAULT_DATEOFBIRTH;
                else
                    model.DateOfBirth = user.DateOfBirth.ToString();
            }

            return model;
        }
    }
}
