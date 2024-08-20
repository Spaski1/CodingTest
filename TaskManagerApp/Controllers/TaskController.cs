using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagerApp.Data;
using TaskManagerApp.Models.Entities;
using TaskManagerApp.Models.Enums;
using Microsoft.AspNetCore.Http;

namespace TaskManagerApp.Controllers
{
    public class TaskController : Controller
    {
        private readonly TaskData _context;

        public TaskController(TaskData context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var data = _context.Tasks.ToList();
            return View(data);
        }

        [HttpGet("task")]
        public async Task<IActionResult> Index(string searchBy, string searchValue)
        {
            var tasks = _context.Tasks.ToList();

            if(tasks.Count == 0)
            {
                TempData["InfoMessage"] = "Curently There areno Tasks.";
            }
            else
            {
                if (string.IsNullOrEmpty(searchValue))
                {
                    TempData["InfoMessage"] = "Please provide search value";
                    return View(tasks);
                }
                else
                {
                    if(searchBy.ToLower() == "name")
                    {
                        var searchByName = tasks.Where(n => n.Name.ToLower().Contains(searchValue.ToLower()));
                        return View(searchByName);
                    }
                    else if (searchBy.ToLower() == "duedate")
                    {
                        var searchByDate = tasks.Where(n => n.DueDate == DateTime.Parse(searchValue));
                        return View(searchByDate);
                    }
                    else if (searchBy.ToLower() == "status")
                    {
                        if (Enum.TryParse(typeof(Status), searchValue, true, out var status))
                        {
                            var searchByStatus = tasks.Where(n => n.Status == (Status)status);
                            return View(searchByStatus);
                        }
                        else
                        {
                            ModelState.AddModelError("", "Invalid status.");
                            return View(tasks);
                        }
                    }
                }
            }
            return View();
        }

        [HttpGet("details")]
        public async Task<IActionResult> Details(int id)
        {
            var task = await _context.Tasks
                .FirstOrDefaultAsync(m => m.Id == id);

            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TaskEntity task)
        {
            if (ModelState.IsValid)
            {
                _context.Tasks.Add(task);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(task);
        }

        [HttpGet("edit")]
        public IActionResult Edit(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, TaskEntity task)
        {
            if (id != task.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(task);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(task);
        }


        public IActionResult Delete(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var task = _context.Tasks.Find(id);
            _context.Tasks.Remove(task);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
