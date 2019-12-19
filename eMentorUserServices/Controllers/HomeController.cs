using eMentor.Common.Models;
using eMentor.Controllers;
using eMentor.DBContext.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace eMentorUserServices.Controllers
{
    [Route("api/Home")]
    [ApiController]
    public class HomeController : BaseController
    {
        private readonly IGeneralService _generalService;
        private readonly ITokenManager _tokenManager;
        public HomeController(
            IGeneralService generalService,
            IUserService userService,
            ILogger<HomeController> loggerService,
            IHostingEnvironment environment,
            ITokenManager tokenManager) : base(loggerService, environment, userService)
        {
            _tokenManager = tokenManager;
            _generalService = generalService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpPost]
        [Route("[action]")]
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

        [HttpGet]
        [Produces("application/json")]
        [Route("[action]")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetHardCodes(string hardCodeParent)
        {
            try
            {
                return GetOKResult(_generalService.GetHardcodes(hardCodeParent));
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
        public async Task<IActionResult> Logout()
        {
            try
            {
                await _tokenManager.DeactivateCurrentAsync();
                return GetOKResult(HttpStatusCode.OK.ToString());
            }
            catch (Exception ex)
            {
                return GetServerErrorResult(ex.ToString());
            }
        }
    }
}
