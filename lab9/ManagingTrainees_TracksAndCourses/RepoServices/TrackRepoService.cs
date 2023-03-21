using ManagingTrainees_TracksAndCourses.Models;
using Microsoft.EntityFrameworkCore;

namespace ManagingTrainees_TracksAndCourses.RepoServices
{
    public class TrackRepoService : ITrackRepository
    {
        private readonly MainDbContext context;

        public TrackRepoService(MainDbContext context)
        {
            this.context = context;
        }
        public void DeleteTrack(int id)
        {
            var track = context.Tracks.Find(id);
            if (track == null)
                return;
            context.Tracks.Remove(track);
            context.SaveChanges();
        }

        public List<Track> GetAll()
        {
            return context.Tracks.Include(t => t.Trainees).ToList();
        }

        public Track GetDetails(int id)
        {
            var track = context.Tracks.Include(t=>t.Trainees).FirstOrDefault(t=>t.ID == id);
            if (track == null)
                return new Track();
            return track;
        }

        public void Insert(Track track)
        {
            context.Tracks.Add(track); 
            context.SaveChanges();
        }

        public void UpdateTrack(int id, Track track)
        {
            var updatedTrack = context.Tracks.Find(id);
            if (updatedTrack == null)
                return;
            updatedTrack.Name = track.Name;
            updatedTrack.Description = track.Description;
            // update trainees
            context.SaveChanges();
        }
    }
}
