﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using eMentor.DBContext;

namespace eMentor.DBContext.Migrations
{
    [DbContext(typeof(EMentorContext))]
    partial class EMentorContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("eMentor.Entities.Entities.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AvailableTime");

                    b.Property<int>("CourseCategory");

                    b.Property<string>("CourseImage");

                    b.Property<DateTime>("Created");

                    b.Property<string>("Description");

                    b.Property<bool>("IsAvailable");

                    b.Property<bool>("IsDeactivate");

                    b.Property<DateTime>("Modified");

                    b.Property<string>("Name");

                    b.Property<int>("OwnerId");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Course");

                    b.HasData(
                        new { Id = 1, AvailableTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), CourseCategory = 1, Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Description = "Master of Design Architechture", IsAvailable = true, IsDeactivate = false, Modified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Name = "Logo Design Course", OwnerId = 2 },
                        new { Id = 2, AvailableTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), CourseCategory = 2, Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Description = "Hand Drawing", IsAvailable = true, IsDeactivate = false, Modified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Name = "Static Drawing", OwnerId = 3 },
                        new { Id = 3, AvailableTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), CourseCategory = 3, Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Description = "Master of English", IsAvailable = true, IsDeactivate = false, Modified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Name = "English", OwnerId = 4 },
                        new { Id = 4, AvailableTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), CourseCategory = 4, Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Description = "Calculate as A Calculater", IsAvailable = true, IsDeactivate = false, Modified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Name = "Dominate The Dericurtive", OwnerId = 5 },
                        new { Id = 5, AvailableTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), CourseCategory = 5, Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Description = "Become a full stack with JS", IsAvailable = true, IsDeactivate = false, Modified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Name = "JS in a nutshell", OwnerId = 6 },
                        new { Id = 6, AvailableTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), CourseCategory = 7, Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Description = "Learning how a crimer think", IsAvailable = true, IsDeactivate = false, Modified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Name = "Criminal Act", OwnerId = 7 }
                    );
                });

            modelBuilder.Entity("eMentor.Entities.Entities.CourseUserAssociation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CourseId");

                    b.Property<DateTime>("Created");

                    b.Property<bool>("IsDeactivate");

                    b.Property<DateTime>("Modified");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("UserId");

                    b.ToTable("CourseUserAssociation");
                });

            modelBuilder.Entity("eMentor.Entities.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("Avatar");

                    b.Property<DateTime>("Created");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("Email");

                    b.Property<string>("FullName");

                    b.Property<int>("Gender");

                    b.Property<bool>("IsDeactivate");

                    b.Property<bool>("IsFirstLogin");

                    b.Property<bool>("IsHardCode");

                    b.Property<string>("LinkedSite");

                    b.Property<DateTime>("Modified");

                    b.Property<string>("PassCode");

                    b.Property<string>("Phone");

                    b.Property<string>("Rating");

                    b.Property<int>("Role");

                    b.Property<string>("Salt");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("User");

                    b.HasData(
                        new { Id = 1, Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), DateOfBirth = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Email = "admin@gmail.com", FullName = "Mr Admin", Gender = 3, IsDeactivate = false, IsFirstLogin = false, IsHardCode = true, Modified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), PassCode = "4gCaQiDMvnCFGpzB3UXGbWZ0cxFeVAi69XbUtGNZRno=", Phone = "0132666666", Role = 1, Salt = "00000000-0000-0000-0000-000000000000", UserName = "Administrator" },
                        new { Id = 2, Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), DateOfBirth = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Email = "teacher1@gmail.com", FullName = "Mr 1", Gender = 3, IsDeactivate = false, IsFirstLogin = false, IsHardCode = true, Modified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), PassCode = "4gCaQiDMvnCFGpzB3UXGbWZ0cxFeVAi69XbUtGNZRno=", Phone = "0132666665", Role = 2, Salt = "00000000-0000-0000-0000-000000000000", UserName = "Teacher1" },
                        new { Id = 3, Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), DateOfBirth = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Email = "teacher2@gmail.com", FullName = "Mr 2", Gender = 3, IsDeactivate = false, IsFirstLogin = false, IsHardCode = true, Modified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), PassCode = "4gCaQiDMvnCFGpzB3UXGbWZ0cxFeVAi69XbUtGNZRno=", Phone = "0132666664", Role = 2, Salt = "00000000-0000-0000-0000-000000000000", UserName = "Teacher2" },
                        new { Id = 4, Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), DateOfBirth = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Email = "teacher3@gmail.com", FullName = "Mr 3", Gender = 3, IsDeactivate = false, IsFirstLogin = false, IsHardCode = true, Modified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), PassCode = "4gCaQiDMvnCFGpzB3UXGbWZ0cxFeVAi69XbUtGNZRno=", Phone = "0132666663", Role = 2, Salt = "00000000-0000-0000-0000-000000000000", UserName = "Teacher3" },
                        new { Id = 5, Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), DateOfBirth = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Email = "teacher4@gmail.com", FullName = "Mr 4", Gender = 3, IsDeactivate = false, IsFirstLogin = false, IsHardCode = true, Modified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), PassCode = "4gCaQiDMvnCFGpzB3UXGbWZ0cxFeVAi69XbUtGNZRno=", Phone = "0132666662", Role = 2, Salt = "00000000-0000-0000-0000-000000000000", UserName = "Teacher4" },
                        new { Id = 6, Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), DateOfBirth = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Email = "teacher5@gmail.com", FullName = "Mr 5", Gender = 3, IsDeactivate = false, IsFirstLogin = false, IsHardCode = true, Modified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), PassCode = "4gCaQiDMvnCFGpzB3UXGbWZ0cxFeVAi69XbUtGNZRno=", Phone = "0132666661", Role = 2, Salt = "00000000-0000-0000-0000-000000000000", UserName = "Teacher5" },
                        new { Id = 7, Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), DateOfBirth = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Email = "teacher6@gmail.com", FullName = "Mr 6", Gender = 3, IsDeactivate = false, IsFirstLogin = false, IsHardCode = true, Modified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), PassCode = "4gCaQiDMvnCFGpzB3UXGbWZ0cxFeVAi69XbUtGNZRno=", Phone = "0132666660", Role = 2, Salt = "00000000-0000-0000-0000-000000000000", UserName = "Teacher6" },
                        new { Id = 8, Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), DateOfBirth = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Email = "student1@gmail.com", FullName = "St 1", Gender = 3, IsDeactivate = false, IsFirstLogin = false, IsHardCode = true, Modified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), PassCode = "4gCaQiDMvnCFGpzB3UXGbWZ0cxFeVAi69XbUtGNZRno=", Phone = "0132666666", Role = 3, Salt = "00000000-0000-0000-0000-000000000000", UserName = "Student1" }
                    );
                });

            modelBuilder.Entity("eMentor.Entities.HardCode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<bool>("IsDeactivate");

                    b.Property<DateTime>("Modified");

                    b.Property<string>("Name");

                    b.Property<string>("ParentId");

                    b.Property<int>("Value");

                    b.HasKey("Id");

                    b.ToTable("HardCode");

                    b.HasData(
                        new { Id = 1, Created = new DateTime(2019, 12, 14, 21, 10, 39, 622, DateTimeKind.Utc), IsDeactivate = false, Modified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Name = "UserRole", Value = 0 },
                        new { Id = 2, Created = new DateTime(2019, 12, 14, 21, 10, 39, 622, DateTimeKind.Utc), IsDeactivate = false, Modified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Name = "Admin", ParentId = "UserRole", Value = 1 },
                        new { Id = 3, Created = new DateTime(2019, 12, 14, 21, 10, 39, 622, DateTimeKind.Utc), IsDeactivate = false, Modified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Name = "Teacher", ParentId = "UserRole", Value = 2 },
                        new { Id = 4, Created = new DateTime(2019, 12, 14, 21, 10, 39, 622, DateTimeKind.Utc), IsDeactivate = false, Modified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Name = "Student", ParentId = "UserRole", Value = 3 },
                        new { Id = 5, Created = new DateTime(2019, 12, 14, 21, 10, 39, 622, DateTimeKind.Utc), IsDeactivate = false, Modified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Name = "Gender", Value = 0 },
                        new { Id = 6, Created = new DateTime(2019, 12, 14, 21, 10, 39, 622, DateTimeKind.Utc), IsDeactivate = false, Modified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Name = "Male", ParentId = "Gender", Value = 1 },
                        new { Id = 7, Created = new DateTime(2019, 12, 14, 21, 10, 39, 622, DateTimeKind.Utc), IsDeactivate = false, Modified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Name = "Female", ParentId = "Gender", Value = 2 },
                        new { Id = 8, Created = new DateTime(2019, 12, 14, 21, 10, 39, 622, DateTimeKind.Utc), IsDeactivate = false, Modified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Name = "Other", ParentId = "Gender", Value = 3 },
                        new { Id = 9, Created = new DateTime(2019, 12, 14, 21, 10, 39, 622, DateTimeKind.Utc), IsDeactivate = false, Modified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Name = "CourseCategories", Value = 0 },
                        new { Id = 10, Created = new DateTime(2019, 12, 14, 21, 10, 39, 622, DateTimeKind.Utc), IsDeactivate = false, Modified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Name = "Design", ParentId = "CourseCategories", Value = 1 },
                        new { Id = 11, Created = new DateTime(2019, 12, 14, 21, 10, 39, 622, DateTimeKind.Utc), IsDeactivate = false, Modified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Name = "Drawing", ParentId = "CourseCategories", Value = 2 },
                        new { Id = 12, Created = new DateTime(2019, 12, 14, 21, 10, 39, 622, DateTimeKind.Utc), IsDeactivate = false, Modified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Name = "Language", ParentId = "CourseCategories", Value = 3 },
                        new { Id = 13, Created = new DateTime(2019, 12, 14, 21, 10, 39, 622, DateTimeKind.Utc), IsDeactivate = false, Modified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Name = "Math", ParentId = "CourseCategories", Value = 4 },
                        new { Id = 14, Created = new DateTime(2019, 12, 14, 21, 10, 39, 622, DateTimeKind.Utc), IsDeactivate = false, Modified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Name = "Programming", ParentId = "CourseCategories", Value = 5 },
                        new { Id = 15, Created = new DateTime(2019, 12, 14, 21, 10, 39, 622, DateTimeKind.Utc), IsDeactivate = false, Modified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Name = "Science", ParentId = "CourseCategories", Value = 6 },
                        new { Id = 16, Created = new DateTime(2019, 12, 14, 21, 10, 39, 622, DateTimeKind.Utc), IsDeactivate = false, Modified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Name = "Psycho", ParentId = "CourseCategories", Value = 7 }
                    );
                });

            modelBuilder.Entity("eMentor.Entities.Entities.Course", b =>
                {
                    b.HasOne("eMentor.Entities.Entities.User", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("eMentor.Entities.Entities.CourseUserAssociation", b =>
                {
                    b.HasOne("eMentor.Entities.Entities.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("eMentor.Entities.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
