using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebSales.Models;

namespace WebSales.Data
{
    public class WebSalesContext : DbContext
    {
        public WebSalesContext (DbContextOptions<WebSalesContext> options)
            : base(options)
        {
        }

        public DbSet<Magics> Magics { get; set; } = default!;
        public DbSet<Decks> Decks { get; set; } = default!;
        public DbSet<Players> Players { get; set; } = default!;
        public DbSet<Tournaments> Tournaments { get; set; } = default!;
    }
}
