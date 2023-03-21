using ManagingTrainees_TracksAndCourses.Models;
using ManagingTrainees_TracksAndCourses.RepoServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagingTrainees_TracksAndCourses.Controllers
{
    public class TraineeController : Controller
    {
        public ITraineeRepository TraineeRepository { get; }
        public ITrackRepository TrackRepository { get; }

        public TraineeController(ITraineeRepository traineeRepository, ITrackRepository trackRepository)
        {
            TraineeRepository = traineeRepository;
            TrackRepository = trackRepository;
        }
        // GET: TaineeController
        public ActionResult Index()
        {
            ViewBag.tracks = TrackRepository.GetAll();
            return View(TraineeRepository.GetAll());
        }

        // GET: TaineeController/Details/5
        public ActionResult Details(int id)
        {
            return View(TraineeRepository.GetDetails(id));
        }

        // GET: TaineeController/Create
        public ActionResult Create()
        {
            ViewBag.tracks = TrackRepository.GetAll();
            return View();
        }

        // POST: TaineeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Trainee trainee)
        {
            ViewBag.tracks = TrackRepository.GetAll();
            try
            {
                TraineeRepository.Insert(trainee);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TaineeController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.tracks = TrackRepository.GetAll();

            return View(TraineeRepository.GetDetails(id));
        }

        // POST: TaineeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Trainee trainee)
        {
            ViewBag.tracks = TrackRepository.GetAll();

            try
            {
                TraineeRepository.UpdateTrainee(id, trainee);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TaineeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(TraineeRepository.GetDetails(id));
        }

        // POST: TaineeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Trainee trainee)
        {
            try
            {
                TraineeRepository.DeleteTrainee(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
