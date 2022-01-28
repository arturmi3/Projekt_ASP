using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

using eBilet2.Models;

namespace eBilet2.Data
{
    public class eBilet2Context : IdentityDbContext
    {
        public eBilet2Context(DbContextOptions<eBilet2Context> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Ticket> Tickets { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new DbInitializer(modelBuilder).Seed();
        }
    }

    public class DbInitializer
    {
        private readonly ModelBuilder modelBuilder;

        public DbInitializer(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }

        public void Seed()
        {
            DateTime t;
            
            t = new DateTime(2022, 5, 1, 12, 0, 0);
            modelBuilder.Entity<Event>().HasData(
                   new Event() { Id = 1, Name = "Koncert z okazji 1 maja", Localization = "Warszawa, Sala Kongresowa", EventType = EventType.Concert, Date = t.Date, Time = default(DateTime).Add(t.TimeOfDay), TicketLimit = 3000, });
            
            t = new DateTime(2022, 5, 15, 20, 0, 0);
            modelBuilder.Entity<Event>().HasData(
                   new Event() { Id = 2, Name = "Mecz Zaksa - Projekt Warszawa", Localization = "Warszawa, Tauron Arena", EventType = EventType.Sport, Date = t.Date, Time = default(DateTime).Add(t.TimeOfDay), TicketLimit = 10000, });

            t = new DateTime(2022, 5, 20, 21, 30, 0);
            modelBuilder.Entity<Event>().HasData(
                   new Event() { Id = 3, Name = "Predator 009", Localization = "Kraków", EventType = EventType.Movie, Date = t.Date, Time = default(DateTime).Add(t.TimeOfDay), TicketLimit = 100, });
        }
    }
}
