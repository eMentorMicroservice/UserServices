using eMentor.Common.Models;
using eMentor.Common.Utils;
using eMentor.Controllers;
using eMentor.DBContext.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eMentorUserServices.Controllers
{
    [Route("api/user")]
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
        [Route("register")]
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
    }
}
