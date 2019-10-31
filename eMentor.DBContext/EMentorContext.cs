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
        public DbSet<Course> Course { get; set; }
        public DbSet<CourseUserAssociation> CourseUserAssociation { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region HardCode
            var salt = new Guid().ToString();
            var index = 1;

            modelBuilder.Entity<User>().HasData(new User { Id = index++, UserName = "Administrator", Email = "admin@gmail.com", FullName = "Mr Admin", Salt = salt, PassCode = UtilCommon.GeneratePasscode("123456x@X", salt), Gender = Gender.Other, Role = UserRole.Administrator, Phone = "0132666666", IsDeactivate = false, IsFirstLogin = false, IsHardCode = true});
            modelBuilder.Entity<User>().HasData(new User { Id = index++, UserName = "Teacher1", Email = "teacher1@gmail.com", FullName = "Mr 1", Salt = salt, PassCode = UtilCommon.GeneratePasscode("123456x@X", salt), Gender = Gender.Other, Role = UserRole.Teacher, Phone = "0132666665", IsDeactivate = false, IsFirstLogin = false, IsHardCode = true });
            modelBuilder.Entity<User>().HasData(new User { Id = index++, UserName = "Teacher2", Email = "teacher2@gmail.com", FullName = "Mr 2", Salt = salt, PassCode = UtilCommon.GeneratePasscode("123456x@X", salt), Gender = Gender.Other, Role = UserRole.Teacher, Phone = "0132666664", IsDeactivate = false, IsFirstLogin = false, IsHardCode = true });
            modelBuilder.Entity<User>().HasData(new User { Id = index++, UserName = "Teacher3", Email = "teacher3@gmail.com", FullName = "Mr 3", Salt = salt, PassCode = UtilCommon.GeneratePasscode("123456x@X", salt), Gender = Gender.Other, Role = UserRole.Teacher, Phone = "0132666663", IsDeactivate = false, IsFirstLogin = false, IsHardCode = true });
            modelBuilder.Entity<User>().HasData(new User { Id = index++, UserName = "Teacher4", Email = "teacher4@gmail.com", FullName = "Mr 4", Salt = salt, PassCode = UtilCommon.GeneratePasscode("123456x@X", salt), Gender = Gender.Other, Role = UserRole.Teacher, Phone = "0132666662", IsDeactivate = false, IsFirstLogin = false, IsHardCode = true });
            modelBuilder.Entity<User>().HasData(new User { Id = index++, UserName = "Teacher5", Email = "teacher5@gmail.com", FullName = "Mr 5", Salt = salt, PassCode = UtilCommon.GeneratePasscode("123456x@X", salt), Gender = Gender.Other, Role = UserRole.Teacher, Phone = "0132666661", IsDeactivate = false, IsFirstLogin = false, IsHardCode = true });
            modelBuilder.Entity<User>().HasData(new User { Id = index++, UserName = "Teacher6", Email = "teacher6@gmail.com", FullName = "Mr 6", Salt = salt, PassCode = UtilCommon.GeneratePasscode("123456x@X", salt), Gender = Gender.Other, Role = UserRole.Teacher, Phone = "0132666660", IsDeactivate = false, IsFirstLogin = false, IsHardCode = true });


            index = 1;
            modelBuilder.Entity<HardCode>().HasData(new HardCode { Id = index++, Name = "UserRole", Created = DateTime.UtcNow, ParentId = null, Value = 0 });
            modelBuilder.Entity<HardCode>().HasData(new HardCode { Id = index++, Name = "Admin", Created = DateTime.UtcNow, ParentId = "UserRole", Value = (int)UserRole.Administrator });
            modelBuilder.Entity<HardCode>().HasData(new HardCode { Id = index++, Name = "Teacher", Created = DateTime.UtcNow, ParentId = "UserRole", Value = (int)UserRole.Teacher });
            modelBuilder.Entity<HardCode>().HasData(new HardCode { Id = index++, Name = "Student", Created = DateTime.UtcNow, ParentId = "UserRole", Value = (int)UserRole.Student });
            modelBuilder.Entity<HardCode>().HasData(new HardCode { Id = index++, Name = "Gender", Created = DateTime.UtcNow, ParentId = null, Value = 0 });
            modelBuilder.Entity<HardCode>().HasData(new HardCode { Id = index++, Name = "Male", Created = DateTime.UtcNow, ParentId = "Gender", Value = (int)Gender.Male });
            modelBuilder.Entity<HardCode>().HasData(new HardCode { Id = index++, Name = "Female", Created = DateTime.UtcNow, ParentId = "Gender", Value = (int)Gender.Female });
            modelBuilder.Entity<HardCode>().HasData(new HardCode { Id = index++, Name = "Other", Created = DateTime.UtcNow, ParentId = "Gender", Value = (int)Gender.Other });

            #endregion
        }
    }
}
