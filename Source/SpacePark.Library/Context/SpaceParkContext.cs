using Microsoft.EntityFrameworkCore;
using SpacePark.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpacePark.Library.Context
{
    public class SpaceParkContext : DbContext
    {
        public DbSet<SpacePort> SpacePorts { get; set; }
        public DbSet<ParkingLot> PlarkingLots { get; set; }
        public DbSet<Visitor> Visitors { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-GO4PDLN;Database=SpaceParkDB;Trusted_Connection=True;");
        }
    }
}
