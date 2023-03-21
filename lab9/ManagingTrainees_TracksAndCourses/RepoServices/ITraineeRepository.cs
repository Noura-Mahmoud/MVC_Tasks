using ManagingTrainees_TracksAndCourses.Models;

namespace ManagingTrainees_TracksAndCourses.RepoServices
{
    public interface ITraineeRepository
    {
        public List<Trainee> GetAll();
        public Trainee GetDetails(int id);
        public void Insert(Trainee trainee);
        public void UpdateTrainee(int id, Trainee trainee);
        public void DeleteTrainee(int id);
    }
}
