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
        public string AvailableFrom { get; set; }
        public string AvailableTo { get; set; }
        public CourseType CourseCategory { get; set; }
        public string CourseImage { get; set; }
        public double CourseFee { get; set; }
    }

    public static class CreateCourseModelEmm
    {
        public static Course ToEntity(this CourseModel model, Course course)
        {
            course = course ?? new Course();
            course.Name = model.Name;
            course.Description = model.Description;
            course.CourseCategory = model.CourseCategory;
            course.AvailableFrom = UtilCommon.ConvertDateTime(model.AvailableFrom, Constants.DATETIME_FORMAT);
            course.AvailableTo = UtilCommon.ConvertDateTime(model.AvailableTo, Constants.DATETIME_FORMAT);
            course.CourseFee = model.CourseFee;
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
                CourseCategory = model.CourseCategory,
                CourseImage = model.CourseImage,
                AvailableFrom = model.AvailableFrom,
                AvailableTo = model.AvailableTo,
                CourseFee = model.CourseFee
            };

            return vm;
        }
    }
}
