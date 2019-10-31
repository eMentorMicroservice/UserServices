using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eMentor.Common.ApiModels;
using eMentor.Common.Models;
using eMentor.Common.Utils;
using eMentor.DBContext.Repositories;
using eMentor.DBContext.Repositories.impl;
using eMentor.Entities.Entities;
using Microsoft.AspNetCore.Http;

namespace eMentor.DBContext.Services.impl
{
    public class CourseService : BaseService, ICourseService
    {
        private ICourseRepository _courseRepo;
        private ICourseUserAssociationRepository _courseUserMapRepo;
        public CourseService(DbContextFactory contextFactory) : base(contextFactory)
        {
            _courseRepo = new CourseRepository(contextFactory);
            _courseUserMapRepo = new CourseUserAssociationRepository(contextFactory);
        }
        public async Task<CourseApiModel> CreateCourse(CourseModel model, int ownerId)
        {
            var entity = new Course();
            try
            {
                var result = new CourseApiModel();
                entity.OwnerId = ownerId;
                entity = model.ToEntity(entity);

                await _courseRepo.InsertAsync(entity);

                

                var users = _courseUserMapRepo.GetUserByCourseId(entity.Id);
                var owner = await _userRepo.GetByIdAsync(ownerId);

                result = entity.ToModel();
                return result;
            }
            catch (Exception ex)
            {
                if (entity.Id != 0)
                    await _courseRepo.DeleteAsync(entity);
                return null;
            }
        }

        public async Task<CourseApiModel> EditCourse(CourseModel model, int userId)
        {
            try
            {
                var result = new CourseApiModel();

                var entity = await _courseRepo.GetByIdAsync(model.Id);

                if (entity == null) return result;

                entity = model.ToEntity(entity);

                await _courseRepo.UpdateAsync(entity);
               
                var owner = await _userRepo.GetByIdAsync(userId);

                result = entity.ToModel();
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IList<CourseApiModel>> GetCourses(int userId, string term, int? courseId = null)
        {
            IList<CourseApiModel> models = new List<CourseApiModel>();
            IList<Course> courses = new List<Course>();

            if (courseId == null)
            {
                var user = await _userRepo.GetByIdAsync(userId);

                if (user.Role == UtilEnum.UserRole.Administrator)
                {
                    if (!string.IsNullOrEmpty(term))
                        courses = _courseRepo.GetCoursesByTerm(term);
                    else
                        courses = _courseRepo.GetCourses();
                }
                else
                {
                    if (!string.IsNullOrEmpty(term))
                        courses = _courseUserMapRepo.GetCoursesByUserAndTerm(userId, term);
                    else
                        courses = _courseUserMapRepo.GetCoursesByUser(userId);
                }
            }
            else
            {
                var proj = await _courseRepo.GetCourseAsync(courseId.Value);
                courses.Add(proj);
            }

            models = courses.ToListModels();

            return models;
        }

        public async Task<ResponseModel> RemoveCourse(int courseId, int userId)
        {
            var respone = new ResponseModel();
            var course = await _courseRepo.GetByIdAsync(courseId);
            var user = await _userRepo.GetByIdAsync(userId);
            if (course == null)
            {
                respone.Status = System.Net.HttpStatusCode.BadRequest;
                respone.Error = ErrorMessageCode.COURSE_NOT_FOUND;
            }
            else
            {
                try
                {
                    var users = _courseUserMapRepo.GetUserByCourseId(courseId);

                    await _courseRepo.DeleteAsync(course);

                    var userCourseMap = _courseUserMapRepo.GetByCourse(courseId);

                    await _courseUserMapRepo.DeleteAsync(userCourseMap);

                    respone.IsSuccess = true;

                    respone.Status = System.Net.HttpStatusCode.OK;

                }
                catch (Exception ex)
                {
                    respone.Status = System.Net.HttpStatusCode.InternalServerError;
                    respone.Error = ex.ToString();
                }

            }

            return respone;

        }
    }
}
