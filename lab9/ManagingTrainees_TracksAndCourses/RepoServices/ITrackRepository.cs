using ManagingTrainees_TracksAndCourses.Models;

namespace ManagingTrainees_TracksAndCourses.RepoServices
{
    public interface ITrackRepository
    {
        public List<Track> GetAll();
        public Track GetDetails(int id);
        public void Insert(Track track);
        public void UpdateTrack(int id, Track track);
        public void DeleteTrack(int id);
    }
}
