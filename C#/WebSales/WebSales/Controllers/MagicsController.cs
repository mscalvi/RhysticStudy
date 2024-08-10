using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebSales.Data;
using WebSales.Models;

namespace WebSales.Controllers
{
    public class MagicsController : Controller
    {
        private readonly WebSalesContext _context;

        public MagicsController(WebSalesContext context)
        {
            _context = context;
        }

        // GET: Magics
        public async Task<IActionResult> Index()
        {
            return View(await _context.Magics.ToListAsync());
        }
    }
}
