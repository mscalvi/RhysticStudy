using WebSales.Data;
using WebSales.Models;
using System.Collections.Generic;

namespace WebSales.Services
{
    public class TournamentsServices
    {
        private readonly WebSalesContext _context;

        public TournamentsServices(WebSalesContext context)
        {
            _context = context;
        }

        public List<Tournaments> FindAll()
        {
            return _context.Tournaments.ToList();
        }

        public void Insert(Tournaments obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }
    }

}