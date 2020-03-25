using Microsoft.EntityFrameworkCore;
using SpacePark.Library.Models;

namespace SpacePark.Library.Context
{
    public class SpaceParkContext : DbContext
    {
        public DbSet<SpacePort> SpacePorts { get; set; } 
        public DbSet<Parking> Parkings { get; set; }
        public DbSet<Visitor> Visitors { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<VisitorParking> VisitorParking { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=ADGNASCOR-THINK\SQLEXPRESS;Database=SpaceParkDB;Trusted_Connection=True;");
        }
    }
}
