﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eMentor.Common.Models;
using eMentor.Controllers;
using eMentor.DBContext.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace eMentorUserServices.Controllers
{
    [Route("api/course")]
    [ApiController]
    public class CourseController : BaseController
    {
        private readonly ITokenManager _tokenManager;
        private readonly ICourseService _courseService;
        public CourseController(
            IUserService userService,
            ILogger<HomeController> loggerService,
            IHostingEnvironment environment,
            ICourseService courseService,
            ITokenManager tokenManager) : base(loggerService, environment, userService)
        {
            _courseService = courseService;
            _tokenManager = tokenManager;
        }
        // GET api/values
        [HttpPost]
        [Produces("application/json")]
        [Route("[action]")]
        public async Task<IActionResult> CreateCourse([FromForm]CourseModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();
                var result = await _courseService.CreateCourse(model, CurrentUser.UserId);
                if (result != null)
                {
                    return GetOKResult(result);
                }

                return GetServerErrorResult(ErrorMessageCode.SERVER_ERROR);
            }
            catch (Exception ex)
            {
                return GetServerErrorResult(ex.ToString());
            }
        }


        [HttpGet]
        [Produces("application/json")]
        [Route("[action]")]
        public async Task<IActionResult> GetProjects(string term = "", int? id = null, bool isViewCourse = false)
        {
            try
            {
                var result = await _courseService.GetCourses(CurrentUser.UserId, term, id);
                if (result != null)
                {
                    if (id != null)
                    {
                        if (isViewCourse)
                        {
                            return GetOKResult(result[0]);
                        }
                        else
                        {
                            return GetOKResult(result[0].ToViewModel());
                        }
                    }

                    return GetOKResult(result);
                }

                return GetServerErrorResult(ErrorMessageCode.SERVER_ERROR);
            }
            catch (Exception ex)
            {
                return GetServerErrorResult(ex.ToString());
            }
        }

        [HttpPost]
        [Produces("application/json")]
        [Route("[action]")]
        public async Task<IActionResult> RemoveProject(int courseId)
        {
            if (courseId == 0) return GetBadRequestResult(ErrorMessageCode.COURSE_NOT_FOUND);

            try
            {

                return GetResult(await _courseService.RemoveCourse(courseId, CurrentUser.UserId));

            }
            catch (Exception ex)
            {
                return GetServerErrorResult(ex.ToString());
            }

        }


        /// <summary>
        /// Edit Project.
        /// </summary>
        /// <returns>Edit Project.</returns>
        /// <response code="200">Project</response>
        /// <response code="500">Server Error.</response>
        [HttpPost]
        [Produces("application/json")]
        [Route("[action]")]
        public async Task<IActionResult> EditProject([FromForm]CourseModel model)
        {
            try
            {
                var result = await _courseService.EditCourse(model, CurrentUser.UserId);
                if (result != null)
                {
                    return GetOKResult(result);
                }

                return GetServerErrorResult(ErrorMessageCode.SERVER_ERROR);
            }
            catch (Exception ex)
            {
                return GetServerErrorResult(ex.ToString());
            }
        }
    }
}
