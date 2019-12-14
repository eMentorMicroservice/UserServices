using eMentor.Common.Models;
using eMentor.Common.Utils;
using eMentor.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using static eMentor.Common.Utils.UtilEnum;

namespace eMentor.Common.ApiModels
{
    public class CourseApiModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string AvailableTime { get; set; }

        public CourseType CourseCategory { get; set; }

        public string CourseImage { get; set; }

        public int OwnerId { get; set; }

        public User Owner { get; set; }

        public CourseApiModel()
        {
        }
    }
    public static class SettingApiModelEmm
    {
        public static CourseApiModel ToModel(this Course entity)
        {
            var model = new CourseApiModel();
            model.Id = entity.Id;
            model.Name = entity.Name;
            model.Description = entity.Description;
            model.OwnerId = entity.OwnerId;
            model.Owner = entity.Owner;
            model.CourseCategory = entity.CourseCategory;

            if (string.IsNullOrWhiteSpace(entity.AvailableTime.ToString()))
                model.AvailableTime = Constants.DEFAULT_DATEOFBIRTH;
            else
                model.AvailableTime = entity.AvailableTime.ToString();

            model.CourseImage = UtilCommon.GetDisplayImageUrl(entity.CourseImage);

            return model;
        }


        public static List<CourseApiModel> ToListModels(this IList<Course> entities)
        {
            var models = new List<CourseApiModel>();
            foreach (var item in entities)
            {
                models.Add(item.ToModel());
            }
            return models;
        }
    }
}
