using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebSales.Models.ViewModels;

namespace WebSales.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        ViewData["Message"] = "Teste Home";

        return View();
    }

    public IActionResult About()
    {
        ViewData["Message"] = "Teste About";

        return View();
    }

    public IActionResult Privacy()
    {
        ViewData["Message"] = "Teste Privacy";

        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
