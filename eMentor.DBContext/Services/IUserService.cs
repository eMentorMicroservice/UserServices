using eMentor.Common.Models;
using eMentor.Entities.Entities;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eMentor.DBContext.Services
{
    public interface IUserService
    {
        Task<ResponseModel> LoginUser(LoginModel apiLoginModel);

        Task<ResponseModel> CreateUser(UserApiModel model);

        Task<User> GetUserById(int id);

        User GetUserAdmin();

        string ValidateAddUserData(UserApiModel model);

        List<User> GetStudents();

        List<User> GetTeachers();

        Task<ResponseModel> ChangePasscode(int idUser, ChangePasscodeModel changePasscode);
        Task<User> GetUserProfile(UserTokenModel currentUser);
        Task<int> EditProfile(UserApiModel model, IFormFile uploadedFile, User userEntity);
    }
}
