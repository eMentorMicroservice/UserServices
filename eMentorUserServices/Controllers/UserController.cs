using eMentor.Common.Models;
using eMentor.Common.Utils;
using eMentor.Controllers;
using eMentor.DBContext.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
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
        public UserController(
            IUserService userService,
            ILogger<HomeController> loggerService,
            IHostingEnvironment environment,
            ITokenManager tokenManager) : base(loggerService, environment, userService)
        {
            _tokenManager = tokenManager;
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

        
        [HttpPost]
        [Route("[action]")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> ChangePasscode([FromBody] ChangePasscodeModel model)
        {
            if (model == null || string.IsNullOrWhiteSpace(model.NewPasscode) || string.IsNullOrWhiteSpace(model.OldPasscode)) return GetBadRequestResult(ErrorMessageCode.FIELDS_IS_EMPTY);

            try
            {
                var userId = CurrentUser.UserId;
                var response = await _userService.ChangePasscode(userId, model);

                return GetResult(response);
            }
            catch (Exception ex)
            {
                return GetServerErrorResult(ex.ToString());
            }
        }
    }
}
