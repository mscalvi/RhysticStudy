using Microsoft.AspNetCore.Mvc;

namespace WebSales.Controllers
{
    public class TournamentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
