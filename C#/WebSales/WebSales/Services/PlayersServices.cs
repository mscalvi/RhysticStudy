using WebSales.Data;
using WebSales.Models;

public class PlayersServices : IPlayersServices
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
}