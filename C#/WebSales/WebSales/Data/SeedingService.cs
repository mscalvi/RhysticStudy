using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Drawing.Text;
using WebSales.Models;
using WebSales.Models.Enums;

namespace WebSales.Data
{
    public class SeedingService
    {
        private WebSalesContext _context;

        public SeedingService(WebSalesContext context)
        {
            _context = context;
        }

        public void Seed() 
        {
            if (_context.Tournaments.Any() || _context.Players.Any() || _context.Magics.Any() || _context.Decks.Any())
            {
                return;
            }
            
            Magics m1 = new Magics(1, "Creature");
            Magics m2 = new Magics(2, "Artifacts");
            Magics m3 = new Magics(3, "Enchantments");
            Magics m4 = new Magics(4, "Instants");
            Magics m5 = new Magics(5, "Sorceries");
            Magics m6 = new Magics(6, "Planeswalkers");

            Decks d1 = new Decks(1, "Inalla", Archetypes.Commander);
            Decks d2 = new Decks(2, "TolkienCompany", Archetypes.Modern);

            Players p1 = new Players(1, "Marcelo", d1);
            Players p2 = new Players(2, "Vivian", d2);

            Tournaments t1 = new Tournaments(1, "OpenModerninho", new DateTime(2023, 5, 30), 32, TournamentStatus.Finished, Archetypes.Modern);
            Tournaments t2 = new Tournaments(2, "CommanderAmor", new DateTime(2023, 5, 31), 16, TournamentStatus.OnGoing, Archetypes.Commander);

            _context.Tournaments.AddRange(t1, t2);
            _context.Players.AddRange(p1, p2);
            _context.Decks.AddRange(d1, d2);
            _context.Magics.AddRange(m1, m2, m3, m4, m5, m6);

            try
            {
                _context.SaveChanges(); // Tenta salvar as mudanças
            }
            catch (DbUpdateException ex)
            {
                // Captura a exceção interna para análise
                Console.WriteLine(ex.InnerException?.Message);

                // Lança novamente a exceção para verificação adicional, se necessário
                throw;
            }
        }
    }
}
