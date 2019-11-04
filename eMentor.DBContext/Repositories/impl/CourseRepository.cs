using eMentor.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
namespace eMentor.DBContext.Repositories.impl
{
    public class CourseRepository : BaseRepository<Course>, ICourseRepository
    {
        public CourseRepository(DbContextFactory contextFactory) : base(contextFactory)
        {

        }
        public async Task<Course> GetCourseAsync(int courseId)
        {
            return await FirstOrDefaultAsync(p => p.Id == courseId);
        }

        public IList<Course> GetCourses(int? courseId = null)
        {
            IList<Course> courses = new List<Course>();
            if (courseId == null)
            {
                using (var context = ContextFactory.CreateDbContext())
                {
                    var query = from b in context.Set<Course>().Include(p=>p.Owner)
                                select b;


                    return query.ToList();
                }
            }
            else
            {
                courses.Add(FirstOrDefault(p => p.Id == courseId.Value));
            }
            return courses;
        }

        public IList<Course> GetCoursesByTerm(string term)
        {
            using (var context = ContextFactory.CreateDbContext())
            {
                var query = from b in context.Set<Course>().Include(p => p.Owner)
                            where b.Name.Contains(term)
                            select b;

                return query.ToList();
            }
        }

        public int GetTotalCourse()
        {
            return GetAll(p => !p.IsDeactivate).Count;
        }
    }
}
