using eMentor.Entities.Entities;
using System.Collections.Generic;

namespace eMentor.DBContext.Repositories
{
    public interface IUserRespository : IBaseRepository<User>
    {
        List<int> GetAllUserId();

        List<User> SearchUserByName(string term, int userId);

        User GetUserByNameAsync(string userName, bool includeDeactivated = false);

        User GetUserByPhoneAsync(string phone, bool includeDeactivated = false);

        User GetUserByEmailAsync(string email, bool includeDeactivated = false);

        List<User> GetAllUser(int userId);

        User GetUserAdmin();

        bool IsUserExists(string userName);
    }
}
