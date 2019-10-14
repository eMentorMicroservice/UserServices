using eMentor.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using static eMentor.Common.Utils.UtilEnum;

namespace eMentor.DBContext
{
    public class EMentorContext : DbContext
    {
        public EMentorContext(DbContextOptions options) : base(options) { }
        public DbSet<HardCode> HardCode { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region HardCode

            modelBuilder.Entity<HardCode>().HasData(new HardCode { Id = 1, Name = "UserRole", Created = DateTime.UtcNow, ParentId = null, Value = 0 });
            modelBuilder.Entity<HardCode>().HasData(new HardCode { Id = 2, Name = "Quản Trị Viên", Created = DateTime.UtcNow, ParentId = "UserRole", Value = (int)UserRole.Administrator });
            modelBuilder.Entity<HardCode>().HasData(new HardCode { Id = 4, Name = "Quản Lý", Created = DateTime.UtcNow, ParentId = "UserRole", Value = (int)UserRole.Teacher });
            modelBuilder.Entity<HardCode>().HasData(new HardCode { Id = 5, Name = "Nhân Viên", Created = DateTime.UtcNow, ParentId = "UserRole", Value = (int)UserRole.Student });

            modelBuilder.Entity<HardCode>().HasData(new HardCode { Id = 20, Name = "Gender", Created = DateTime.UtcNow, ParentId = null, Value = 0 });
            modelBuilder.Entity<HardCode>().HasData(new HardCode { Id = 21, Name = "Nam", Created = DateTime.UtcNow, ParentId = "Gender", Value = (int)Gender.Male });
            modelBuilder.Entity<HardCode>().HasData(new HardCode { Id = 22, Name = "Nữ", Created = DateTime.UtcNow, ParentId = "Gender", Value = (int)Gender.Female });
            modelBuilder.Entity<HardCode>().HasData(new HardCode { Id = 23, Name = "Khác", Created = DateTime.UtcNow, ParentId = "Gender", Value = (int)Gender.Other });

            #endregion
        }
    }
}
