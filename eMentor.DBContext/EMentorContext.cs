using eMentor.Common.Utils;
using eMentor.Entities;
using eMentor.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using static eMentor.Common.Utils.UtilEnum;

namespace eMentor.DBContext
{
    public class EMentorContext : DbContext
    {
        public EMentorContext(DbContextOptions options) : base(options) { }
        public DbSet<HardCode> HardCode { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region HardCode
            var salt = new Guid().ToString();
            modelBuilder.Entity<User>().HasData(new User { Id = 1, UserName = "Administrator", Email = "admin@gmail.com", FullName = "Mr Admin", Salt = salt, PassCode = UtilCommon.GeneratePasscode("123456x@X", salt), Gender = Gender.Other, Role = UserRole.Administrator, Phone = "0132666666", IsDeactivate = false, IsFirstLogin = false, IsHardCode = true});
            modelBuilder.Entity<HardCode>().HasData(new HardCode { Id = 1, Name = "UserRole", Created = DateTime.UtcNow, ParentId = null, Value = 0 });
            modelBuilder.Entity<HardCode>().HasData(new HardCode { Id = 2, Name = "Admin", Created = DateTime.UtcNow, ParentId = "UserRole", Value = (int)UserRole.Administrator });
            modelBuilder.Entity<HardCode>().HasData(new HardCode { Id = 4, Name = "Teacher", Created = DateTime.UtcNow, ParentId = "UserRole", Value = (int)UserRole.Teacher });
            modelBuilder.Entity<HardCode>().HasData(new HardCode { Id = 5, Name = "Student", Created = DateTime.UtcNow, ParentId = "UserRole", Value = (int)UserRole.Student });
            modelBuilder.Entity<HardCode>().HasData(new HardCode { Id = 6, Name = "Gender", Created = DateTime.UtcNow, ParentId = null, Value = 0 });
            modelBuilder.Entity<HardCode>().HasData(new HardCode { Id = 7, Name = "Male", Created = DateTime.UtcNow, ParentId = "Gender", Value = (int)Gender.Male });
            modelBuilder.Entity<HardCode>().HasData(new HardCode { Id = 8, Name = "Female", Created = DateTime.UtcNow, ParentId = "Gender", Value = (int)Gender.Female });
            modelBuilder.Entity<HardCode>().HasData(new HardCode { Id = 9, Name = "Other", Created = DateTime.UtcNow, ParentId = "Gender", Value = (int)Gender.Other });

            #endregion
        }
    }
}
