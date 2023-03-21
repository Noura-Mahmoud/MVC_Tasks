using ManagingTrainees_TracksAndCourses.Models;

namespace ManagingTrainees_TracksAndCourses.RepoServices
{
    public interface ICourseRepository
    {
        public List<Course> GetAll();
        public Course GetDetails(int id);
        public void Insert(Course crs);
        public void UpdateCrs(int id, Course Crs);
        public void DeleteCrs(int id);
    }
}
