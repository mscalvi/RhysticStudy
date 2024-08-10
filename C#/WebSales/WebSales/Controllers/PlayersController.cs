using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebSales.Data;
using WebSales.Models;
using WebSales.Services;

namespace WebSales.Controllers
{
    public class PlayersController : Controller
    {
        private readonly PlayersServices _playersServices;

        public PlayersController(PlayersServices playerServices)
        {
            _playersServices = playerServices;
        }
        public IActionResult Index()
        {
            var list = _playersServices.FindAll();

            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Players player)
        {
            _playersServices.Insert(player);
            return RedirectToAction(nameof(Index));
        }
    }
}
