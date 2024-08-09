using WebSales.Models.Enums;

namespace WebSales.Models
{
    public class Tournaments
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int PlayerNumber { get; set; }
        public TournamentStatus Status { get; set; }
        public Archetypes Archetype { get; set; }
    }
}
