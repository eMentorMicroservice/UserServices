using eMentor.Common.Models;
using eMentor.Common.Utils;
using eMentor.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eMentor.DBContext.Services.impl
{
    public class UserExperimentService : BaseService, IUserExperimentService
    {
        private readonly IJwtHandler _jwtHandler;

        public UserExperimentService(DbContextFactory contextFactory, IJwtHandler jwtHandler) : base(contextFactory)
        {
            _jwtHandler = jwtHandler;
        }

        public IList<UserExperienceModel> GetUserExperiences(int userId)
        {
            var model = new List<UserExperienceModel>();
            var entitys = _userExperienceRepository.GetUserExperiencesByUserId(userId);
            foreach (var e in entitys)
            {
                model.Add(e.ToUserExpModel());
            }
            return model;
        }

        public async Task<int> UpdateUserExp(UserExperienceModels model, int userId)
        {
            var counter = 0;

            UserExperience userEntity = new UserExperience();
            foreach (var item in model.UserExperienceModel)
            {
                counter++;
                userEntity = item.ToEntity(userEntity);
                userEntity.MentorId = userId;
                if (item.Id == 0)
                    await _userExperienceRepository.InsertAsync(userEntity);
                else
                    await _userExperienceRepository.UpdateAsync(userEntity);
                if (model.Counter == counter) break;
            }

            return 1;
        }
    }
}
