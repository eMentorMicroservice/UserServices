using eMentor.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace eMentor.Common.Models
{
    public class UserExperienceModel
    {
        public int Id { get; set; }
        public string JobTitle { get; set; }
        public string CompanySite { get; set; }
        public string Description { get; set; }
        public string Time { get; set; }
        public int MentorId { get; set; }
    }

    public class UserExperienceModels
    {
        public UserExperienceModels()
        {
            UserExperienceModel = new List<UserExperienceModel>();
        }
        public IList<UserExperienceModel> UserExperienceModel { get; set; }
        public int Counter { get; set; }
    }

    public static class UserExperienceModelEmm
    {
        public static UserExperience ToEntity(this UserExperienceModel model, UserExperience entity)
        {
            if (entity == null)
                entity = new UserExperience();
            entity.Id = model.Id;
            entity.JobTitle = model.JobTitle;
            entity.Description = model.Description;
            entity.CompanySite = model.CompanySite;
            entity.Time = model.Time;
            entity.MentorId = model.MentorId;
            return entity;
        }

        public static UserExperienceModel ToUserExpModel(this UserExperience userExp)
        {
            var model = new UserExperienceModel();

            if (userExp != null)
            {
                model.Id = userExp.Id;
                model.JobTitle = userExp.JobTitle;
                model.Description = userExp.Description;
                model.CompanySite = userExp.CompanySite;
                model.Time = userExp.Time;
                model.MentorId = userExp.MentorId;
            }

            return model;
        }
    }
}
