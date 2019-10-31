using eMentor.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eMentor.DBContext.Repositories
{
    public interface ICourseRepository: IBaseRepository<Course>
    {
        int GetTotalCourse();

        IList<Course> GetCourses(int? courseId = null);
        Task<Course> GetCourseAsync(int courseId);
        IList<Course> GetCoursesByTerm(string term);
    }
}
