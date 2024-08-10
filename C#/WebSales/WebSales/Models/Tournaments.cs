﻿using WebSales.Models.Enums;
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
        public double Amount { get; set; }
        public TournamentStatus Status { get; set; }
        public Archetypes Archetype { get; set; }
        public ICollection<Players> Players { get; set; } = new List<Players>();

        public Tournaments() { }
        public Tournaments(int id, string name, DateTime date, double amount, int playerNumber, TournamentStatus status, Archetypes archetype)
        {
            Id = id;
            Name = name;
            Date = date;
            Amount = amount;
            PlayerNumber = playerNumber;
            Status = status;
            Archetype = archetype;
        }
        public void AddPlayer(Players player)
        {
            Players.Add(player);
        }
    }
}
