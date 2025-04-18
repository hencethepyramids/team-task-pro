using Microsoft.AspNetCore.Mvc;

namespace TeamTaskPro.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Reports()
    {
        return View();
    }

    public IActionResult Team()
    {
        return View();
    }

    public IActionResult Settings()
    {
        return View();
    }
} 