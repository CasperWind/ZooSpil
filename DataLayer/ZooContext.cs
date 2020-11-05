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
        public DbSet<UserDyr> UserDyrs { get; set; }
        public DbSet<UserKunder> UserKunders { get; set; }
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
            modelBuilder.Entity<UserDyr>()
                .HasKey(Key => new { Key.UserId, Key.DyrId });

            modelBuilder.Entity<UserKunder>()
                .HasKey(Key => new { Key.UserID, Key.KundeId });

            modelBuilder.Entity<Dyr>().HasData(
                new Dyr { DyrId = 1, Pris = 10000, Navn = "🐊" },
                new Dyr { DyrId = 2, Pris = 10000, Navn = "🦁" },
                new Dyr { DyrId = 3, Pris = 10000, Navn = "🐘" },
                new Dyr { DyrId = 4, Pris = 10000, Navn = "🐧" },
                new Dyr { DyrId = 5, Pris = 10000, Navn = "🐉" },
                new Dyr { DyrId = 6, Pris = 10000, Navn = "🐯" }
                );

            modelBuilder.Entity<Kunder>().HasData(
                new Kunder { KundeId = 1, Navn = "Famile" },
                new Kunder { KundeId = 2, Navn = "Par" },
                new Kunder { KundeId = 3, Navn = "Unge" }
                );
        }
    }
   
}
