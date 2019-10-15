#if LOGGER
using Logger;
#endif

using eMentor.Common.Models;
using eMentor.DBContext.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Net;
using static eMentor.Common.Utils.UtilEnum;

namespace eMentor.Controllers
{
    /// <summary>
    /// BaseController
    /// </summary>
    public abstract class BaseController : ControllerBase
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        protected readonly IUserService _userService;
        protected readonly ILogger<BaseController> _loggerService;

        protected UserTokenModel CurrentUser { get { return GetUserIdentify(); } }

        /// <summary>
        ///  Constructor
        /// </summary>
        /// <param name="loggerService"></param>
        /// <param name="environment"></param>
        /// <param name="userService"></param>
        public BaseController(ILogger<BaseController> loggerService, IHostingEnvironment environment, IUserService userService)
        {
            _userService = userService;
            _hostingEnvironment = environment;
            _loggerService = loggerService;
        }

        /// <summary>
        /// Get DomainN ame
        /// </summary>
        /// <returns>string</returns>
        protected string GetDomainName()
        {
            var host = HttpContext.Request.Host.Value;
            return HttpContext.Request.IsHttps ? "https://" + host : "http://" + host;
        }

        /// <summary>
        /// Get User Identify
        /// </summary>
        /// <returns>UserTokenModel</returns>
        protected UserTokenModel GetUserIdentify()
        {

            //Get user id from token - using on future
            var userModel = new UserTokenModel();

            var identity = HttpContext.User.Identity as System.Security.Claims.ClaimsIdentity;

            if (identity == null) return null;

            userModel.UserId = Convert.ToInt32(identity.Name);

            userModel.UserRole = (UserRole)Convert.ToInt32(identity.Claims.FirstOrDefault(p => p.Type.Equals("Role")).Value);

            var user = _userService.GetUserById(userModel.UserId).Result;

            if (user == null) return null;

            userModel.FullName = user.FullName;

            return userModel;
        }
        /// <summary>
        /// Get Server Error Result
        /// </summary>
        /// <param name="ex"></param>
        /// <returns>ApiErrorModel</returns>

        protected IActionResult GetServerErrorResult(string ex)
        {
            var response = new ApiErrorModel();
            response.Error.Code = HttpStatusCode.InternalServerError.ToString();
            response.Error.Message = ErrorMessageCode.SERVER_ERROR;
            response.Error.InnerError = ex;
            return StatusCode(StatusCodes.Status500InternalServerError, response);
        }
        /// <summary>
        ///  Get Unauthorized Result
        /// </summary>
        /// <returns>ApiErrorModel</returns>

        protected IActionResult GetUnauthorizedResult()
        {
            var response = new ApiErrorModel();
            response.Error.Code = HttpStatusCode.Unauthorized.ToString();
            return StatusCode(StatusCodes.Status401Unauthorized, response);
        }
        /// <summary>
        ///  Get Forbidden Error Result
        /// </summary>
        /// <returns>ApiErrorModel</returns>
        protected IActionResult GetForbiddenErrorResult()
        {
            var response = new ApiErrorModel();
            response.Error.Code = HttpStatusCode.Forbidden.ToString();
            response.Error.Message = ErrorMessageCode.AUTH_FORBIDDEN_ERROR;
            response.Error.InnerError = "";
            return StatusCode(StatusCodes.Status403Forbidden, response);
        }

        /// <summary>
        ///  Get OK Result
        /// </summary>
        /// <param name="result"></param>
        /// <returns>object</returns>
        protected IActionResult GetOKResult(object result)
        {
            return Ok(result);
        }

        /// <summary>
        /// Get Bad Request Result
        /// </summary>
        /// <param name="message"></param>
        /// <returns>ApiErrorModel</returns>
        protected IActionResult GetBadRequestResult(string message)
        {
            var response = new ApiErrorModel();
            response.Error.Code = HttpStatusCode.BadRequest.ToString();
            response.Error.Message = message;

            return BadRequest(response);
        }

        /// <summary>
        ///  GetResult
        /// </summary>
        /// <param name="model"></param>
        /// <returns>ResponseModel</returns>
        protected IActionResult GetResult(ResponseModel model)
        {
            if (model == null) return GetServerErrorResult(ErrorMessageCode.SERVER_ERROR);

            switch (model.Status)
            {
                case HttpStatusCode.InternalServerError:
                    return GetServerErrorResult(model.Error);
                case HttpStatusCode.BadRequest:
                    return GetBadRequestResult(model.Error);
                case HttpStatusCode.OK:
                    return GetOKResult(model.Data != null ? model.Data : model.IsSuccess);
                case HttpStatusCode.NotImplemented:
                    return GetServerErrorResult(model.Error);
                default:
                    return GetServerErrorResult(model.Error);
            }
        }

        /// <summary>
        /// Get Not Found Result
        /// </summary>
        /// <param name="message"></param>
        /// <returns>ApiErrorModel</returns>
        protected IActionResult GetNotFoundResult(string message)
        {
            var response = new ApiErrorModel();
            response.Error.Code = HttpStatusCode.BadRequest.ToString();
            response.Error.Message = message;

            return NotFound(response);
        }
    }
}
