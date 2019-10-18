using eMentor.Common.Models;
using eMentor.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using static eMentor.Common.Utils.UtilEnum;

namespace eMentor.DBContext.Repositories.impl
{
    public class UserRepository : BaseRepository<User>, IUserRespository
    {
        public UserRepository(DbContextFactory contextFactory) : base(contextFactory)
        {

        }
        public  List<int> GetAllUserId()
        {
            return  GetAll(q => !q.IsHardCode).Select(p => p.Id).ToList();
        }

        public  User GetUserByEmailAsync(string email, bool includeDeactivated = false)
        {
            return  FirstOrDefault(p => p.Email == email, includeDeactivated);
        }

        public  User GetUserByNameAsync(string userName, bool includeDeactivated = false)
        {
            return FirstOrDefault(p => p.UserName == userName, includeDeactivated);
        }

        public  List<User> SearchUserByName(string term, int userId)
        {
            return GetAll(p => p.FullName.Contains(term) &&  p.Role != UserRole.Administrator && p.Id != userId).ToList();
        }

        public User GetUserAdmin()
        {
            return FirstOrDefault(p => p.Role == UserRole.Administrator && p.IsHardCode , false);
        }

        public bool IsUserExists(string email)
        {
            return GetAll(p => p.Email == email, false).Any();
        }

        public List<User> GetAllUser(int userId)
        {
            return GetAll(p => p.Role != UserRole.Administrator && p.Id != userId).ToList();
        }
    }
}
