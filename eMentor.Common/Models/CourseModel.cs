using eMentor.Common.ApiModels;
using eMentor.Common.Utils;
using eMentor.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using static eMentor.Common.Utils.UtilEnum;

namespace eMentor.Common.Models
{
    public class CourseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string AvailableTime { get; set; }
        public CourseType CourseCategory { get; set; }
        public string CourseImage { get; set; }
    }

    public static class CreateCourseModelEmm
    {
        public static Course ToEntity(this CourseModel model, Course course)
        {
            course = course ?? new Course();
            course.Name = model.Name;
            course.Description = model.Description;
            course.CourseCategory = model.CourseCategory;
            course.AvailableTime = UtilCommon.ConvertDateTime(model.AvailableTime, Constants.DATETIME_FORMAT);
            course.Id = model.Id;
            return course;
        }

        public static CourseModel ToViewModel(this CourseApiModel model)
        {
            var vm = new CourseModel()
            {
                Description = model.Description,
                Id = model.Id,
                Name = model.Name,
            };

            return vm;
        }
    }
}
