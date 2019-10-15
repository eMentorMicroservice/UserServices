using eMentor.Controllers;
using eMentor.DBContext.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

namespace eMentorUserServices.Controllers
{
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
    }
}
