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
using static eMentor.Common.Utils.UtilEnum;

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
        public async Task<CourseApiModel> CreateCourse(CourseModel model, int ownerId, IFormFile uploadedFile)
        {
            var entity = new Course();
            try
            {
                var result = new CourseApiModel();

                entity.OwnerId = ownerId;

                entity.CourseImage = UtilCommon.ImageUpload(Constants.UserDataFolderName, uploadedFile, "", false);

                entity = model.ToEntity(entity);

                await _courseRepo.InsertAsync(entity);

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

        public async Task<CourseApiModel> EditCourse(CourseModel model, int userId, IFormFile uploadedFile)
        {
            try
            {
                var result = new CourseApiModel();

                var entity = await _courseRepo.GetByIdAsync(model.Id);

                if (entity == null) return result;

                entity = model.ToEntity(entity);

                entity.CourseImage = UtilCommon.ImageUpload(Constants.UserDataFolderName, uploadedFile, "", false);

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

        public async Task<IList<CourseApiModel>> GetCourseByMentor(int mentorId)
        {
            IList<CourseApiModel> models = new List<CourseApiModel>();
            IList<Course> courses = new List<Course>();

            courses = await _courseRepo.GetAllAsync();
            models = courses.Where(x=>x.OwnerId == mentorId).ToList().ToListModels();

            foreach (var each in models)
            {
                each.CategoryModel = _hardCodeRepository.GetHardCode(typeof(CourseType), (int)each.CourseCategory).ToModel();
            }

            return models;
        }

        public async Task<IList<CourseApiModel>> GetCourses(string term, int? courseId = null)
        {
            IList<CourseApiModel> models = new List<CourseApiModel>();
            IList<Course> courses = new List<Course>();

            if (courseId == null)
            {
                    if (!string.IsNullOrEmpty(term))
                        courses = _courseRepo.GetCoursesByTerm(term);
                    else
                        courses = _courseRepo.GetCourses();
            }
            else
            {
                var proj = await _courseRepo.GetCourseAsync(courseId.Value);
                courses.Add(proj);
            }

            models = courses.ToListModels();

            foreach (var each in models)
            {
                each.CategoryModel = _hardCodeRepository.GetHardCode(typeof(CourseType), (int)each.CourseCategory).ToModel();
            }

            return models;
        }

        public async Task<ResponseModel> RemoveCourse(int courseId, int userId)
        {
            var respone = new ResponseModel();
            var course = await _courseRepo.GetByIdAsync(courseId);
            
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
