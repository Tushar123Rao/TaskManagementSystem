using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Data;
using TaskManagementSystem.Models;
using TaskManagementSystem.ViewModels;
using TaskStatus = TaskManagementSystem.Models.Enums.TaskStatus;

namespace TaskManagementSystem.Controllers
{
    public class TaskController : Controller
    {
        private readonly ApplicationDbContext _context;
        public TaskController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var tasks = _context.TaskItems.ToList();
            return View(tasks);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateTaskViewModel model)
        {
            if (ModelState.IsValid)
            {
                var taskitem = new TaskItem
                {
                    Title = model.Title,
                    Description = model.Description,
                    Status = model.Status,
                    Priority = model.Priority,
                    DueDate = model.DueDate,
                    ReminderDateTime = model.ReminderDateTime,
                    IsCompleted = false,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = null,
                    UserId = "temp-user"
                };
                _context.TaskItems.Add(taskitem);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult MarkComplete(int id)
        {
            var item = _context.TaskItems.FirstOrDefault(i => i.Id == id);
            if(item == null)
            {
                return NotFound();
            }
            item.IsCompleted = true;
            item.Status = TaskStatus.Completed;
            item.UpdatedAt = DateTime.Now;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
