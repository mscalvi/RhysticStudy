using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebSales.Data;
using WebSales.Models;
using WebSales.Services;

namespace WebSales.Controllers
{
    public class TournamentsController : Controller
    {
        private readonly TournamentsServices _tournamentsServices;

        public TournamentsController(TournamentsServices tournamentsServices)
        {
            _tournamentsServices = tournamentsServices;
        }

        public IActionResult Index()
        {
            var list = _tournamentsServices.FindAll();

            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Tournaments tournament)
        {
            _tournamentsServices.Insert(tournament);
            return RedirectToAction(nameof(Index));
        }
    }
}
