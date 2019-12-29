using eMentor.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace eMentor.DBContext.Repositories
{
    public interface IUserExperienceRepository : IBaseRepository<UserExperience>
    {
        IList<UserExperience> GetUserExperiencesByUserId(int? userId = null);
    }
}
