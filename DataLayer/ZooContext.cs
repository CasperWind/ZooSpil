using DataLayer.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public class ZooContext : DbContext
    {
        public DbSet<Dyr> Dyrs { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Kunder> Kunders { get; set; }
        public ZooContext()
        {

        }

        public ZooContext(DbContextOptions<ZooContext> options)
            : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = ZooDB; Trusted_Connection = True; ");
            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dyr>().HasData(
                new Dyr { DyrId = 1, Antal = 0, Navn = "Elefant" },
                new Dyr { DyrId = 2, Antal = 0, Navn = "Abe" },
                new Dyr { DyrId = 3, Antal = 0, Navn = "Tiger" },
                new Dyr { DyrId = 4, Antal = 0, Navn = "Løve" },
                new Dyr { DyrId = 5, Antal = 0, Navn = "Flodhest" },
                new Dyr { DyrId = 6, Antal = 0, Navn = "Dovendyr" }
                );

            modelBuilder.Entity<Kunder>().HasData(
                new Kunder { KundeId = 1, Navn = "Famile", Antal = 0 },
                new Kunder { KundeId = 2, Navn = "Par", Antal = 0 },
                new Kunder { KundeId = 3, Navn = "Unge", Antal = 0 }
                );
        }
    }
   
}
