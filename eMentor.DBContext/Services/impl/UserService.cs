using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using eMentor.Common.ApiModels;
using eMentor.Common.Models;
using eMentor.Common.Utils;
using eMentor.Entities.Entities;
using Microsoft.AspNetCore.Http;
using static eMentor.Common.Utils.UtilEnum;

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

        public async Task<ResponseModel> CreateUser(UserApiModel model)
        {
            var response = new ResponseModel();

            try
            {
                var user = model.ToEntity(new User());

                user.Salt = Guid.NewGuid().ToString().Replace("-", "");
                user.PassCode = UtilCommon.GeneratePasscode(model.PassWord, user.Salt);
                user.Role = UserRole.Student;

                var insert = await _userRepo.InsertAsync(user);

                if (insert > -1)
                {
                    response.Data = insert;
                    response.IsSuccess = true;
                    response.Status = HttpStatusCode.OK;
                    return response;
                }
                else
                {
                    response.IsSuccess = false;
                    response.Error = ErrorMessageCode.SERVER_ERROR;
                    response.Status = HttpStatusCode.InternalServerError;
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Error = ex.ToString();
                response.Status = HttpStatusCode.InternalServerError;
                return response;
            }
        }

        public string ValidateAddUserData(UserApiModel model)
        {
            return _userRepo.ValidateAddUserData(model);
        }

        public List<User> GetStudents()
        {
            return _userRepo.GetUsers(UserRole.Student);
        }

        public List<User> GetTeachers()
        {
            return _userRepo.GetUsers(UserRole.Teacher);
        }

        public async Task<ResponseModel> ChangePasscode(int idUser, ChangePasscodeModel changePasscode)
        {
            ResponseModel result = new ResponseModel();

            if (!UtilCommon.IsValidPassword(changePasscode.NewPasscode))
            {
                result.Error = ErrorMessageCode.PASSWORD_INVALID;
                result.Status = System.Net.HttpStatusCode.BadRequest;
                return result;
            }

            var user = await _userRepo.GetByIdAsync(idUser);

            if (user == null)
            {
                result.Error = ErrorMessageCode.USER_NOT_FOUND;
                result.Status = System.Net.HttpStatusCode.BadRequest;
                return result;
            }

            if (!user.PassCode.Equals(UtilCommon.GeneratePasscode(changePasscode.OldPasscode, user.Salt)))
            {
                result.Error = ErrorMessageCode.PASSWORD_INVALID;
                result.Status = System.Net.HttpStatusCode.BadRequest;
                return result;
            }

            try
            {
                string newPasscode = UtilCommon.GeneratePasscode(changePasscode.NewPasscode, user.Salt);

                user.PassCode = newPasscode;
                var res = await _userRepo.UpdateAsync(user);
                if (res != Constants.REPOSITORY_FAILED)
                {
                    result.Status = System.Net.HttpStatusCode.OK;
                    result.IsSuccess = true;
                    if (user.IsFirstLogin)
                    {
                        user.IsFirstLogin = false;
                        await _userRepo.UpdateAsync(user);
                    }
                    return result;
                }
                else
                {
                    result.Error = ErrorMessageCode.UPDATE_PASSWORD_FAILED;
                    result.Status = System.Net.HttpStatusCode.InternalServerError;
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

        public async Task<User> GetUserProfile(UserTokenModel currentUser)
        {
            return await _userRepo.GetByIdAsync(currentUser.UserId);
        }

        public async Task<int> EditProfile(UserApiModel model, IFormFile uploadedFile, User userEntity)
        {
            userEntity = model.ToEntity(userEntity);

            userEntity.Avatar = UtilCommon.ImageUpload(Constants.UserDataFolderName, uploadedFile, userEntity.Avatar, false);

            return await _userRepo.UpdateAsync(userEntity);
        }
    }
}
