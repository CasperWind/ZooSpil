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
    }
   
}
