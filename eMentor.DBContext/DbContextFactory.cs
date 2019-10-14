using eMentor.DBContext.Services;
using Microsoft.EntityFrameworkCore;

namespace eMentor.DBContext
{
    public class DbContextFactory : IDbContextFactory
    {
        private IAppSettingService _appSettingService;

        public DbContextFactory(IAppSettingService appSettingService)
        {
            _appSettingService = appSettingService;
        }

        public EMentorContext CreateDbContext()
        {
            return CreateDbContext(null);
        }

        public EMentorContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<EMentorContext>();
            builder.UseMySql(_appSettingService.ConnectionString);
            return new EMentorContext(builder.Options);
        }
    }
}
