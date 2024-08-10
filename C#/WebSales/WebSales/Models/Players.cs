using System.Collections.Generic;
using System.Linq;

namespace WebSales.Models
{
    public class Players
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Decks> Decks { get; set; } = new List<Decks>();
        public int Age { get; set; }
        public int Ranking { get; set; }
        public ICollection<Tournaments> TournamentsPlayed { get; set; } = new List<Tournaments>();

        public Players() { }
        public Players(int id, string name, Decks deck)
        {
            Id = id;
            Name = name;
            Decks.Add(deck);
        }

        public void AddDecks(Decks decks)
        {
            Decks.Add(decks);
        }
        public void RemoveDecks(Decks decks)
        {
            Decks.Remove(decks);
        }
        public double PlayedTournaments(DateTime initial, DateTime final)
        {
            return TournamentsPlayed.Count(TournamentsPlayed => TournamentsPlayed.Date >= initial && TournamentsPlayed.Date <= final);
        }


    }
}
