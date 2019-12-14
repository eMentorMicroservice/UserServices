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
            modelBuilder.Entity<User>().HasData(new User { Id = index++, UserName = "Student1", Email = "student1@gmail.com", FullName = "St 1", Salt = salt, PassCode = UtilCommon.GeneratePasscode("123456x@X", salt), Gender = Gender.Other, Role = UserRole.Student, Phone = "0132666666", IsDeactivate = false, IsFirstLogin = false, IsHardCode = true });

            index = 1;
            modelBuilder.Entity<Course>().HasData(new Course { Id = index++, Name = "Logo Design Course", CourseCategory = CourseType.Design, Description = "Master of Design Architechture", OwnerId= 2, IsAvailable=true, IsDeactivate = false });
            modelBuilder.Entity<Course>().HasData(new Course { Id = index++, Name = "Static Drawing", CourseCategory = CourseType.Drawing, Description = "Hand Drawing", OwnerId = 3, IsAvailable = true, IsDeactivate = false });
            modelBuilder.Entity<Course>().HasData(new Course { Id = index++, Name = "English", CourseCategory = CourseType.Language, Description = "Master of English", OwnerId = 4, IsAvailable = true, IsDeactivate = false });
            modelBuilder.Entity<Course>().HasData(new Course { Id = index++, Name = "Dominate The Dericurtive", CourseCategory = CourseType.Math, Description = "Calculate as A Calculater", OwnerId = 5, IsAvailable = true, IsDeactivate = false });
            modelBuilder.Entity<Course>().HasData(new Course { Id = index++, Name = "JS in a nutshell", CourseCategory = CourseType.Programming, Description = "Become a full stack with JS", OwnerId = 6, IsAvailable = true, IsDeactivate = false });
            modelBuilder.Entity<Course>().HasData(new Course { Id = index++, Name = "Criminal Act", CourseCategory = CourseType.Psycho, Description = "Learning how a crimer think", OwnerId = 7, IsAvailable = true, IsDeactivate = false });


            index = 1;
            modelBuilder.Entity<HardCode>().HasData(new HardCode { Id = index++, Name = "UserRole", Created = DateTime.UtcNow, ParentId = null, Value = 0 });
            modelBuilder.Entity<HardCode>().HasData(new HardCode { Id = index++, Name = "Admin", Created = DateTime.UtcNow, ParentId = "UserRole", Value = (int)UserRole.Administrator });
            modelBuilder.Entity<HardCode>().HasData(new HardCode { Id = index++, Name = "Teacher", Created = DateTime.UtcNow, ParentId = "UserRole", Value = (int)UserRole.Teacher });
            modelBuilder.Entity<HardCode>().HasData(new HardCode { Id = index++, Name = "Student", Created = DateTime.UtcNow, ParentId = "UserRole", Value = (int)UserRole.Student });

            modelBuilder.Entity<HardCode>().HasData(new HardCode { Id = index++, Name = "Gender", Created = DateTime.UtcNow, ParentId = null, Value = 0 });
            modelBuilder.Entity<HardCode>().HasData(new HardCode { Id = index++, Name = "Male", Created = DateTime.UtcNow, ParentId = "Gender", Value = (int)Gender.Male });
            modelBuilder.Entity<HardCode>().HasData(new HardCode { Id = index++, Name = "Female", Created = DateTime.UtcNow, ParentId = "Gender", Value = (int)Gender.Female });
            modelBuilder.Entity<HardCode>().HasData(new HardCode { Id = index++, Name = "Other", Created = DateTime.UtcNow, ParentId = "Gender", Value = (int)Gender.Other });

            modelBuilder.Entity<HardCode>().HasData(new HardCode { Id = index++, Name = "CourseCategories", Created = DateTime.UtcNow, ParentId = null, Value = 0 });
            modelBuilder.Entity<HardCode>().HasData(new HardCode { Id = index++, Name = "Design", Created = DateTime.UtcNow, ParentId = "CourseCategories", Value = (int)CourseType.Design });
            modelBuilder.Entity<HardCode>().HasData(new HardCode { Id = index++, Name = "Drawing", Created = DateTime.UtcNow, ParentId = "CourseCategories", Value = (int)CourseType.Drawing });
            modelBuilder.Entity<HardCode>().HasData(new HardCode { Id = index++, Name = "Language", Created = DateTime.UtcNow, ParentId = "CourseCategories", Value = (int)CourseType.Language });
            modelBuilder.Entity<HardCode>().HasData(new HardCode { Id = index++, Name = "Math", Created = DateTime.UtcNow, ParentId = "CourseCategories", Value = (int)CourseType.Math });
            modelBuilder.Entity<HardCode>().HasData(new HardCode { Id = index++, Name = "Programming", Created = DateTime.UtcNow, ParentId = "CourseCategories", Value = (int)CourseType.Programming });
            modelBuilder.Entity<HardCode>().HasData(new HardCode { Id = index++, Name = "Science", Created = DateTime.UtcNow, ParentId = "CourseCategories", Value = (int)CourseType.Science });
            modelBuilder.Entity<HardCode>().HasData(new HardCode { Id = index++, Name = "Psycho", Created = DateTime.UtcNow, ParentId = "CourseCategories", Value = (int)CourseType.Psycho });

            #endregion
        }
    }
}
