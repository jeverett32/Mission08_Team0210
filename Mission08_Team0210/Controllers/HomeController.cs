using Microsoft.AspNetCore.Mvc;
using Mission08_Team0210.Models;
using Mission08_TeamXXXX.Models;
using System.Diagnostics;

namespace Mission08_Team0210.Controllers
{
    public class HomeController : Controller
    {
        private ITaskRepository _repo;
        public HomeController(ITaskRepository temp) => _repo = temp;
        public IActionResult Index()
        {
            var tasks = _repo.Tasks
                .Where(x => x.Completed == false)
                .ToList();
            return View(tasks);
        }

        [HttpGet]
        public IActionResult AddEdit()
        {
            ViewBag.Categories = _repo.Categories.ToList();
            return View(new TaskModel());
        }
        [HttpPost]
        public IActionResult AddEdit(TaskModel response)
        {
            if (ModelState.IsValid)
            {
                if (response.TaskId == 0)
                {
                    _repo.AddTask(response);
                }
                else
                {
                    _repo.UpdateTask(response);
                }
                return RedirectToAction("Index");
            }

            ViewBag.Categories = _repo.Categories.ToList();
            return View(response);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Categories = _repo.Categories.ToList();
            var task = _repo.Tasks.Single(x => x.TaskId == id);
            return View("AddEdit", task);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var task = _repo.Tasks.Single(x => x.TaskId == id);
            return View(task);
        }
        [HttpPost]
        public IActionResult Delete(TaskModel task)
        {
            _repo.DeleteTask(task);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult MarkComplete(int id)
        {
            var task = _repo.Tasks.Single(x => x.TaskId == id);
            task.Completed = true;
            _repo.UpdateTask(task);
            return RedirectToAction("Index");
        }
    }
}