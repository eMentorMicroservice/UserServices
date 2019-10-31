using eMentor.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace eMentor.DBContext.Repositories
{
    public interface ICourseUserAssociationRepository: IBaseRepository<CourseUserAssociation>
    {
        IList<Course> GetCoursesByUser(int userId);
        IList<User> GetUserByCourseId(int courseId);
        IList<CourseUserAssociation> GetByCourse(int courseId);
        IList<Course> GetCoursesByUserAndTerm(int userId, string term);
        CourseUserAssociation GetByCourseAnduser(int userId, int courseId);
    }
}
