using Microsoft.EntityFrameworkCore;
using Operation_229.Entities;
using Operation_229.Helpers;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operation_229
{
    internal class AirplanesDBContext : DbContext
    {
        public AirplanesDBContext()
        {
           //Database.EnsureDeleted();
           //Database.EnsureCreated();
        }
        public DbSet<Airplane> Airplanes { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Flight> Flights { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
                       optionsBuilder.UseSqlServer($@"Data Source=COREi5;
                                                    Initial Catalog = AirplaneDB2withMigration;
                                                    Integrated Security=True;
                                                    Connect Timeout=30;
                                                    Encrypt=False;
                                                    TrustServerCertificate=False;
                                                    ApplicationIntent=ReadWrite;
                                                    MultiSubnetFailover=False");
            /*            optionsBuilder.UseSqlServer($@"Data Source=SportShop.mssql.somee.com;
                                                         Initial Catalog=AirplaneDB;
                                                         Integrated Security=False;
                                                         User ID=dannykaye7_SQLLogin_1;Password=xgbe9gay2u;
                                                         Connect Timeout = 2");*/
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) // initializer
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.SeedAirplanes();
            modelBuilder.SeedFlights();
            //modelBuilder.Entity<Airplane>().Property(a => a.Model).IsRequired().HasMaxLength(100);
            //modelBuilder.Entity<Flight>().HasKey(s => s.ID); // primary key
            modelBuilder.Entity<Flight>().
                HasMany(f => f.clients).
                WithMany(c => c.flights);
            modelBuilder.Entity<Flight>().
                HasOne(f => f.airplanes).
                WithMany(a => a.flights).
                HasForeignKey(f => f.AirplaneID);
        }
    }
}
