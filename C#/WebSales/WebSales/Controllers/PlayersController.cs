using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebSales.Data;
using WebSales.Models;

namespace WebSales.Controllers
{
    public class PlayersController : Controller
    {
        private readonly PlayersServices _playersServices;

        public PlayersController(PlayersServices playerService)
        {
            _playersServices = playerService;
        }
        public IActionResult Index()
        {
            var list = _playersServices.FindAll();

            return View(list);
        }
    }
}
