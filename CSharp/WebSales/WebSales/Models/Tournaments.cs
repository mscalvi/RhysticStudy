using WebSales.Models.Enums;
using System.Collections.Generic;
using System;
using System.Linq;

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

        public Tournaments() { }
        public Tournaments(int id, string name, DateTime date, int playerNumber, TournamentStatus status, Archetypes archetype)
        {
            Id = id;
            Name = name;
            Date = date;
            PlayerNumber = playerNumber;
            Status = status;
            Archetype = archetype;
        }
    }
}
