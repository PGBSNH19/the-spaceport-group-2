using Microsoft.EntityFrameworkCore;
using SpacePark.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpacePark.Library.Context
{
    public class SpaceParkContext : DbContext
    {
        public DbSet<ParkingLot> PlarkingLots { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<SpacePort> SpacePorts { get; set; }
        public DbSet<Spaceship> Spaceships { get; set; }
        public DbSet<Visitor> Visitors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=SpaceParkDB;Trusted_Connection=True;");
        }
    }
}
