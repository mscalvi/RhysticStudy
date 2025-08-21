using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebSales.Data;
using WebSales.Models;
using WebSales.Models.ViewModels;
using WebSales.Services;

namespace WebSales.Controllers
{
    public class PlayersController : Controller
    {
        private readonly PlayersServices _playersServices;
        private readonly TournamentsServices _tournamentsServices;

        public PlayersController(PlayersServices playerServices, TournamentsServices tournamentsServices)
        {
            _playersServices = playerServices;
            _tournamentsServices = tournamentsServices;
        }
        public IActionResult Index()
        {
            var list = _playersServices.FindAll();

            return View(list);
        }

        public IActionResult Create()
        {
            var tournaments = _tournamentsServices.FindAll();
            var viewModel = new PlayerFormViewModel {  Tournaments = tournaments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Players player)
        {
            Console.WriteLine("Formulário enviado!");
            if (ModelState.IsValid)
            {
                _playersServices.Insert(player);
                return RedirectToAction(nameof(Index));
            }
            var tournaments = _tournamentsServices.FindAll();
            var viewModel = new PlayerFormViewModel { Player = player, Tournaments = tournaments };
            return View(viewModel);
        }
    }
}
