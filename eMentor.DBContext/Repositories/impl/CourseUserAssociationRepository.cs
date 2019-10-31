using eMentor.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace eMentor.DBContext.Repositories.impl
{
    public class CourseUserAssociationRepository : BaseRepository<CourseUserAssociation>, ICourseUserAssociationRepository
    {
        public CourseUserAssociationRepository(DbContextFactory contextFactory) : base(contextFactory)
        {

        }

        public IList<CourseUserAssociation> GetByCourse(int courseId)
        {
            return GetAll(p => p.CourseId == courseId).ToList();
        }

        public CourseUserAssociation GetByCourseAnduser(int userId, int courseId)
        {
            return FirstOrDefault(p => p.UserId == userId && p.CourseId == courseId);
        }

        public IList<Course> GetCoursesByUser(int userId)
        {
            using (var context = ContextFactory.CreateDbContext())
            {
                var query = from b in context.Set<CourseUserAssociation>().Include(p => p.Course)
                             join c in context.Set<Course>().Include(q => q.Owner)
                             on b.CourseId equals c.Id
                             where b.UserId == userId
                             select c;

                return query.ToList();
            }
        }

        public IList<Course> GetCoursesByUserAndTerm(int userId, string term)
        {
            using (var context = ContextFactory.CreateDbContext())
            {
                var query = (from b in context.Set<CourseUserAssociation>().Include(p => p.Course)
                             join c in context.Set<Course>().Include(q => q.Owner)
                             on b.CourseId equals c.Id
                             where b.UserId == userId && c.Name.Contains(term)
                             select c);

                return query.ToList();
            }
        }

        public IList<User> GetUserByCourseId(int courseId)
        {
            return GetAll(p => p.CourseId == courseId)?.Select(p => p.User).ToList();
        }
    }
}
