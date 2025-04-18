using Microsoft.AspNetCore.Mvc;
using TeamTaskPro.Web.Models;

namespace TeamTaskPro.Web.Controllers;

public class TasksController : Controller
{
    public IActionResult Index()
    {
        // TODO: Replace with actual data from database
        var tasks = new List<TaskItem>
        {
            new TaskItem 
            { 
                Id = 1, 
                Title = "Update user interface",
                Description = "Implement new design system",
                Priority = TaskPriority.High,
                Status = TaskItemStatus.Open,
                Category = "Frontend",
                CreatedAt = DateTime.Now.AddDays(-2)
            },
            new TaskItem 
            { 
                Id = 2, 
                Title = "Fix login bug",
                Description = "Users unable to login with Google auth",
                Priority = TaskPriority.High,
                Status = TaskItemStatus.InProgress,
                Category = "Backend",
                CreatedAt = DateTime.Now.AddDays(-1)
            },
            new TaskItem 
            { 
                Id = 3, 
                Title = "Add unit tests",
                Description = "Increase test coverage for core modules",
                Priority = TaskPriority.Medium,
                Status = TaskItemStatus.Open,
                Category = "Testing",
                CreatedAt = DateTime.Now.AddDays(-3)
            }
        };

        return View(tasks);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(TaskItem task)
    {
        if (ModelState.IsValid)
        {
            // TODO: Save to database
            TempData["Success"] = "Task created successfully!";
            return RedirectToAction(nameof(Index));
        }
        return View(task);
    }
} 