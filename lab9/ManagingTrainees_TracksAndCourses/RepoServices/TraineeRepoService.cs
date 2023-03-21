using ManagingTrainees_TracksAndCourses.Models;
using Microsoft.EntityFrameworkCore;

namespace ManagingTrainees_TracksAndCourses.RepoServices
{
    public class TraineeRepoService : ITraineeRepository
    {
        private readonly MainDbContext context;

        public TraineeRepoService(MainDbContext context)
        {
            this.context = context;
        }
        public void DeleteTrainee(int id)
        {
            var trainee = context.Trainees.Find(id);
            if (trainee == null)
                return;
            context.Trainees.Remove(trainee);
            context.SaveChanges();
        }

        public List<Trainee> GetAll()
        {
            return context.Trainees.Include(t=>t.Track).ToList();
        }

        public Trainee GetDetails(int id)
        {
            var trainee = context.Trainees.Include(t => t.Track).FirstOrDefault(t => t.ID == id);
            if (trainee == null)
                return new Trainee();
            return trainee;
        }

        public void Insert(Trainee trainee)
        {
            context.Trainees.Add(trainee);
            context.SaveChanges();
        }

        public void UpdateTrainee(int id, Trainee trainee)
        {
            var updatedTrainee = context.Trainees.Find(id);
            if (updatedTrainee == null)
                return;
            updatedTrainee.Name = trainee.Name;
            updatedTrainee.Gender = trainee.Gender;
            updatedTrainee.Email = trainee.Email;
            updatedTrainee.MobileNo = trainee.MobileNo;
            updatedTrainee.Birthdate = trainee.Birthdate;
            // update courses
            context.SaveChanges();
        }
    }
}
