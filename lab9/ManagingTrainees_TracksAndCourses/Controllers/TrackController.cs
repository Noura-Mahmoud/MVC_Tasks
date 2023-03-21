using ManagingTrainees_TracksAndCourses.Models;
using ManagingTrainees_TracksAndCourses.RepoServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagingTrainees_TracksAndCourses.Controllers
{
    public class TrackController : Controller
    {
        public ITrackRepository TrackRepository { get; }

        public TrackController(ITrackRepository trackRepository)
        {
            TrackRepository = trackRepository;
        }
        // GET: TrackController
        public ActionResult Index()
        {
            return View(TrackRepository.GetAll());
        }

        // GET: TrackController/Details/5
        public ActionResult Details(int id)
        {
            return View(TrackRepository.GetDetails(id));
        }

        // GET: TrackController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TrackController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Track track)
        {
            try
            {
                TrackRepository.Insert(track);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TrackController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(TrackRepository.GetDetails(id));
        }

        // POST: TrackController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Track track)
        {
            try
            {
                TrackRepository.UpdateTrack(id, track);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TrackController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(TrackRepository.GetDetails(id));
        }

        // POST: TrackController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                TrackRepository.DeleteTrack(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
