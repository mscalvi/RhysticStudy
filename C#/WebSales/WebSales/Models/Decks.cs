﻿using WebSales.Models.Enums;

namespace WebSales.Models
{
    public class Decks
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Archetypes Archetypes { get; set; }

        public Decks() { }

        public Decks(int id, string name, Archetypes archetypes)
        {
            Id = id;
            Name = name;
            Archetypes = archetypes;
        }
    }
}