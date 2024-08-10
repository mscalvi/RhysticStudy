using WebSales.Data;
using WebSales.Models;

namespace WebSales.Services
{
    public class PlayersServices
    {
        private readonly WebSalesContext _context;

        public PlayersServices(WebSalesContext context)
        {
            _context = context;
        }

        public List<Players> FindAll()
        {
            return _context.Players.ToList();
        }

        public void Insert(Players obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }
    }

}