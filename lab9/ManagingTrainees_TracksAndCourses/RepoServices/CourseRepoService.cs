using ManagingTrainees_TracksAndCourses.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ManagingTrainees_TracksAndCourses.RepoServices
{
    public class CourseRepoService : ICourseRepository
    {
        private readonly MainDbContext context;

        public CourseRepoService(MainDbContext context)
        {
            this.context = context;
        }
        public void DeleteCrs(int id)
        {
            var crs = context.Courses.Find(id);
            if (crs == null)
                return;
            context.Courses.Remove(crs);
            context.SaveChanges();
        }

        public List<Course> GetAll()
        {
            return context.Courses.ToList();
        }

        public Course GetDetails(int id)
        {
            var crs = context.Courses.Include(c=>c.Trainee).FirstOrDefault(c=>c.ID == id);
            if (crs == null)
                return new Course();
            return crs;
        }

        public void Insert(Course crs)
        {
            context.Courses.Add(crs);
            context.SaveChanges();
        }

        public void UpdateCrs(int id, Course Crs)
        {
            var updatedCourse = context.Courses.Find(id);
            if (updatedCourse == null)
                return;
            updatedCourse.Topic = Crs.Topic;
            updatedCourse.Grade = Crs.Grade;
            context.SaveChanges();
        }
    }
}
