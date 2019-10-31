using eMentor.Common.ApiModels;
using eMentor.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace eMentor.Common.Models
{
    public class CourseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public static class CreateProjectModelEmm
    {
        public static Course ToEntity(this CourseModel model, Course course)
        {
            course = course ?? new Course();
            course.Name = model.Name;
            course.Description = model.Description;
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
