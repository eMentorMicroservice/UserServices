using eMentor.Common.Models;
using eMentor.Controllers;
using eMentor.DBContext.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace eMentorUserServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : BaseController
    {
        private readonly ITokenManager _tokenManager;
        public HomeController(
            IUserService userService,
            ILogger<HomeController> loggerService,
            IHostingEnvironment environment,
            ITokenManager tokenManager) : base(loggerService, environment, userService)
        {
            _tokenManager = tokenManager;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginModel user)
        {
            if (user == null || string.IsNullOrWhiteSpace(user.PassCode)) return GetBadRequestResult(ErrorMessageCode.FIELDS_IS_EMPTY);

            try
            {
                var response = await _userService.LoginUser(user);

                if (response != null && response.Data != null)
                {
                    return GetOKResult(response.Data);
                }
                else
                {
                    return GetResult(response);
                }
            }
            catch (Exception ex)
            {
                return GetServerErrorResult(ex.ToString());
            }
        }
    }
}
