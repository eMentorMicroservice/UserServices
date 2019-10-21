using eMentor.Common.Models;
using eMentor.Controllers;
using eMentor.DBContext.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eMentorUserServices.Controllers
{
    [Route("api/Home")]
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

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            if (model == null || string.IsNullOrWhiteSpace(model.PassCode)) 
                return GetBadRequestResult(ErrorMessageCode.FIELDS_IS_EMPTY);

            try
            {
                var response = await _userService.LoginUser(model);

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
