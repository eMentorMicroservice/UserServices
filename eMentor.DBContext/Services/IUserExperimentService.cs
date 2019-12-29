using eMentor.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eMentor.DBContext.Services
{
    public interface IUserExperimentService
    {
        Task<int> UpdateUserExp(UserExperienceModels model, int userId);
        IList<UserExperienceModel> GetUserExperiences(int userId);
    }
}
