using eMentor.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eMentor.DBContext.Repositories.impl
{
    public class UserExperienceRepository : BaseRepository<UserExperience>, IUserExperienceRepository
    {
        public UserExperienceRepository(DbContextFactory contextFactory) : base(contextFactory)
        {

        }

        public IList<UserExperience> GetUserExperiencesByUserId(int? userId = null)
        {
            return GetAll(p => p.MentorId == userId).ToList();
        }
    }
}
