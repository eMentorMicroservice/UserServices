using eMentor.Common.Models;
using eMentor.Entities.Entities;
using System.Threading.Tasks;

namespace eMentor.DBContext.Services
{
    public interface IUserService
    {
        Task<ResponseModel> LoginUser(LoginModel apiLoginModel);

        Task<User> GetUserById(int id);

        User GetUserAdmin();
    }
}
