using eMentor.Common.Models;
using eMentor.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace eMentor.Common.ApiModels
{
    public class CourseApiModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

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
