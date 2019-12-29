using eMentor.Common.Models;
using eMentor.Common.Utils;
using eMentor.Controllers;
using eMentor.DBContext.Services;
using eMentor.Entities.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eMentorUserServices.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly ITokenManager _tokenManager;
        private readonly IUserExperimentService _userExperimentService;
        public UserController(
            IUserExperimentService userExperimentService,
            IUserService userService,
            ILogger<HomeController> loggerService,
            IHostingEnvironment environment,
            ITokenManager tokenManager) : base(loggerService, environment, userService)
        {
            _tokenManager = tokenManager;
            _userExperimentService = userExperimentService;
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Register([FromBody] UserApiModel model)
        {
            try
            {
                if (!UtilCommon.IsValidEmail(model.Email))
                {
                    return GetBadRequestResult(ErrorMessageCode.EMAIL_INVALID);
                }

                var error = _userService.ValidateAddUserData(model);

                if (!string.IsNullOrEmpty(error))
                {
                    return GetBadRequestResult(error);
                }

                return GetResult(await _userService.CreateUser(model));
            }
            catch (Exception ex)
            {
                return GetServerErrorResult(ex.ToString());
            }
        }

        [HttpGet]
        [Produces("application/json")]
        [Route("[action]")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetUserProfile()
        {
            try
            {
                var user = await _userService.GetUserProfile(CurrentUser);
                if (user != null)
                {
                    var model = user.ToUserModel(CurrentUser.UserRole);
                    model.Exp = new UserExperienceModels();
                    model.Exp.UserExperienceModel = _userExperimentService.GetUserExperiences(CurrentUser.UserId).ToList();
                    model.Exp.Counter = model.Exp.UserExperienceModel.Count();
                    return GetOKResult(model);
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
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetProfileById(int id)
        {
            try
            {
                var user = await _userService.GetUserById(id);

                if (user != null)
                {
                    var model = user.ToUserModel(CurrentUser.UserRole);
                    model.Exp = new UserExperienceModels();
                    model.Exp.UserExperienceModel = _userExperimentService.GetUserExperiences(CurrentUser.UserId).ToList();
                    model.Exp.Counter = model.Exp.UserExperienceModel.Count();
                    return GetOKResult(model);
                }

                return GetServerErrorResult(ErrorMessageCode.SERVER_ERROR);
            }
            catch (Exception ex)
            {
                return GetServerErrorResult(ex.ToString());
            }
        }


        [HttpPost]
        [Route("[action]")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> ChangePasscode([FromBody] ChangePasscodeModel model)
        {
            if (model == null || string.IsNullOrWhiteSpace(model.NewPasscode) || string.IsNullOrWhiteSpace(model.OldPasscode)) return GetBadRequestResult(ErrorMessageCode.FIELDS_IS_EMPTY);

            try
            {
                var response = await _userService.ChangePasscode(CurrentUser.UserId, model);

                return GetResult(response);
            }
            catch (Exception ex)
            {
                return GetServerErrorResult(ex.ToString());
            }
        }

        [HttpPost]
        [Produces("application/json")]
        [Route("[action]")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> EditProfile([FromForm] UserApiModel model, [FromForm(Name = "uploadedFile")]IFormFile uploadedFile)
        {
            try
            {
                if ((!UtilCommon.IsValidEmail(model.Email) || !UtilCommon.IsValidPhone(model.Phone)))
                {
                    return GetBadRequestResult(ErrorMessageCode.EMAIL_OR_PHONE_NUMBER_INVALID);
                }

                var userEntity = await _userService.GetUserById(CurrentUser.UserId);


                return GetOKResult(await _userService.EditProfile(model, uploadedFile, userEntity));
            }
            catch (Exception ex)
            {
                return GetServerErrorResult(ex.ToString());
            }
        }

        [Produces("application/json")]
        [Route("[action]")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> AddOrEditUserExperiment([FromBody] UserExperienceModels model)
        {
            try
            {
                if (model.Counter == 0) return GetOKResult(true);

                return GetOKResult(await _userExperimentService.UpdateUserExp(model, CurrentUser.UserId));
            }
            catch (Exception ex)
            {
                return GetServerErrorResult(ex.ToString());
            }
        }

        [HttpPost]
        [Route("[action]")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> RemoveUser(int userId)
        {
            try
            {
                if (userId == 0) return GetBadRequestResult(ErrorMessageCode.USER_NOT_FOUND);

                return GetResult(await _userService.DeleteUser(userId));

            }
            catch (Exception ex)
            {
                return GetServerErrorResult(ex.ToString());
            }

        }

        [HttpPost]
        [Route("[action]")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> UpgradeUser(int userId)
        {
            try
            {
                if (userId == 0) return GetBadRequestResult(ErrorMessageCode.USER_NOT_FOUND);

                return GetResult(await _userService.UpgradeUser(userId));

            }
            catch (Exception ex)
            {
                return GetServerErrorResult(ex.ToString());
            }

        }

        [HttpGet]
        [Route("[action]")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetAllUser()
        {
            try
            {
                if (CurrentUser.UserRole != UtilEnum.UserRole.Administrator) return GetForbiddenErrorResult();
                var users = await _userService.GetAllUser();
                var model = new List<UserModel>();
                foreach (var user in users)
                {
                    if (user.Role != UtilEnum.UserRole.Administrator) 
                        model.Add(user.ToUserModel(CurrentUser.UserRole));

                }
                if (users != null)
                {
                    return GetOKResult(model);
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
