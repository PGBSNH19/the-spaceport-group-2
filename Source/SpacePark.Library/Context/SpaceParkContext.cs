using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SpacePark.Library.Models;
using System.IO;

namespace SpacePark.Library.Context
{
    public class SpaceParkContext : DbContext
    {
        public DbSet<SpacePort> SpacePorts { get; set; } 
        public DbSet<ParkingLot> ParkingLots { get; set; }
        public DbSet<Visitor> Visitors { get; set; }
        public DbSet<VisitorParking> VisitorParking { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {           
            IConfiguration config = new ConfigurationBuilder()
                  .AddJsonFile("appsettings.json", true, true)
                  .Build();

           optionsBuilder.UseSqlServer(config["ConnectionStrings:DefaultConnection"]);
            
        }

       
    }
}
