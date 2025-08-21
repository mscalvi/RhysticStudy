using System.Collections.Generic;
using System.Linq;

namespace WebSales.Models
{
    public class Players
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Ranking { get; set; }
        public Tournaments Tournaments { get; set; }
        public int TournamentId { get; set; }

        public Players() { }
        public Players(int id, string name, Tournaments tournaments)
        {
            Id = id;
            Name = name;
            TournamentId = tournaments.Id;
            Tournaments = tournaments;
        }
    }
}
