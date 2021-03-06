﻿using eMentor.Common.ApiModels;
using eMentor.Common.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eMentor.DBContext.Services
{
    public interface ICourseService
    {
        Task<CourseApiModel> CreateCourse(CourseModel model, int ownerId, IFormFile uploadedFile);
        Task<IList<CourseApiModel>> GetCourses(string term, int? courseId = null);
        Task<ResponseModel> RemoveCourse(int courseId, int userId);
        Task<CourseApiModel> EditCourse(CourseModel model, int userId, IFormFile uploadedFile);
        Task<IList<CourseApiModel>> GetCourseByMentor(int mentorId);
    }
}
