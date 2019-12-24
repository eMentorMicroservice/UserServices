using eMentor.Common.Models;
using eMentor.Common.Utils;
using eMentor.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static eMentor.Common.Utils.UtilEnum;

namespace eMentor.DBContext.Repositories.impl
{
    public class UserRepository : BaseRepository<User>, IUserRespository
    {
        public UserRepository(DbContextFactory contextFactory) : base(contextFactory)
        {

        }
        public override async Task<User> GetByIdAsync(object id, bool includeDeactive = true)
        {
            using (var context = ContextFactory.CreateDbContext())
            {
                var obj = context.Set<User>().Where(p => p.Id == (int)id).Include(p=>p.Exp);

                if (!includeDeactive)
                    obj.Where(p => p.IsDeactivate == false);

                return await obj.FirstOrDefaultAsync();
            }
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

        public string ValidateAddUserData(UserApiModel model)
        {
            string error = null;

            if (GetAll(p => (p.Email.Equals(model.Email)), false).Any())

                return ErrorMessageCode.EMAIL_OR_PHONE_NUMBER_ALREADY_EXIST;

            return error;
        }

        public List<User> GetUsers(UserRole userRole)
        {
           return GetAll(p => p.Role == userRole).ToList();
        }
    }
}
