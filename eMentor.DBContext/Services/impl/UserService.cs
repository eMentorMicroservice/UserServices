using System;
using System.Net;
using System.Threading.Tasks;
using eMentor.Common.ApiModels;
using eMentor.Common.Models;
using eMentor.Common.Utils;
using eMentor.Entities.Entities;

namespace eMentor.DBContext.Services.impl
{
    public class UserService : BaseService, IUserService
    {
        private readonly IJwtHandler _jwtHandler;

        public UserService(DbContextFactory contextFactory, IJwtHandler jwtHandler) : base(contextFactory)
        {
            _jwtHandler = jwtHandler;
        }
        public User GetUserAdmin()
        {
            return _userRepo.GetUserAdmin();
        }

        public async Task<User> GetUserById(int id)
        {
            return await _userRepo.GetByIdAsync(id);
        }

        public async Task<ResponseModel> LoginUser(LoginModel loginModel)
        {
            ResponseModel result = new ResponseModel();

            User user = null;

            if (!string.IsNullOrWhiteSpace(loginModel.Email))
            {
                user = _userRepo.GetUserByEmailAsync(loginModel.Email, true);
            }

            if (user == null)
            {
                result.Error = ErrorMessageCode.USER_NOT_FOUND;
                result.Status = HttpStatusCode.NotFound;
                return result;
            }

            if (user.IsDeactivate)
            {
                result.Error = ErrorMessageCode.USER_IS_DEACTIVATE;
                result.Status = HttpStatusCode.Forbidden;
                return result;
            }

            try
            {
                var passcode = UtilCommon.GeneratePasscode(loginModel.PassCode, user.Salt);
                var expireToken = 1;
                if (passcode.Equals(user.PassCode))
                {
                    result.Status = System.Net.HttpStatusCode.OK;
                    LoginApiModel data = new LoginApiModel();
                    data.IsFirstLogin = user.IsFirstLogin;
                    //Get Token
                    data.Token = _jwtHandler.Create(user.Id.ToString(), expireToken, user.Role);
                    data.Avatar = UtilCommon.GetDisplayImageUrl(user.Avatar);
                    data.FullName = user.FullName;
                    data.Role = user.Role;
                    data.UserId = user.Id;
                    result.Data = data;
                    await _userRepo.UpdateAsync(user);
                    return result;
                }
                else
                {
                    result.Error = ErrorMessageCode.PASSWORD_INCORRECT;
                    result.Status = System.Net.HttpStatusCode.NotFound;
                    var date = DateTime.UtcNow;
                    return result;
                }
            }
            catch (Exception ex)
            {
                result.Error = ex.ToString();
                result.Status = System.Net.HttpStatusCode.NotImplemented;
                return result;
            }
        }
    }
}
