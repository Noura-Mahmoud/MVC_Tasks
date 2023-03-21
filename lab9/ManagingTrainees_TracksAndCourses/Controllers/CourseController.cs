using ManagingTrainees_TracksAndCourses.Models;
using ManagingTrainees_TracksAndCourses.RepoServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagingTrainees_TracksAndCourses.Controllers
{
    public class CourseController : Controller
    {
        public ICourseRepository CourseRepository { get; }
        public ITraineeRepository TraineeRepository { get; }

        public CourseController(ICourseRepository courseRepository, ITraineeRepository traineeRepository)
        {
            CourseRepository = courseRepository;
            TraineeRepository = traineeRepository;
        }
        // GET: CourseController
        public ActionResult Index()
        {
            ViewBag.trainees = TraineeRepository.GetAll();
            return View(CourseRepository.GetAll());
        }

        // GET: CourseController/Details/5
        public ActionResult Details(int id)
        {
            return View(CourseRepository.GetDetails(id));
        }

        // GET: CourseController/Create
        public ActionResult Create()
        {
            ViewBag.trainees = TraineeRepository.GetAll();
            return View();
        }

        // POST: CourseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Course course)
        { 
            ViewBag.trainees = TraineeRepository.GetAll();
            try
            {
                CourseRepository.Insert(course);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CourseController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.trainees = TraineeRepository.GetAll();
            return View(CourseRepository.GetDetails(id));
        }

        // POST: CourseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Course course)
        {
            ViewBag.trainees = TraineeRepository.GetAll();
            try
            {
                CourseRepository.UpdateCrs(id, course);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CourseController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(CourseRepository.GetDetails(id));
        }

        // POST: CourseController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                CourseRepository.DeleteCrs(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
