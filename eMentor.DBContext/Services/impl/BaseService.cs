using eMentor.Common.Utils;
using eMentor.DBContext.Repositories;
using eMentor.DBContext.Repositories.impl;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace eMentor.DBContext.Services.impl
{
    public abstract class BaseService : IBaseService
    {
        protected IUserRespository _userRepo;
        protected IHardCodeRepository _hardCodeRepository;

        public BaseService(DbContextFactory contextFactory)
        {
            _userRepo = new UserRepository(contextFactory);
            _hardCodeRepository = new HardCodeRepository(contextFactory);
        }
     }
}
