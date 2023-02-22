using Microsoft.EntityFrameworkCore;
using Operation_229.Entities;
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
            modelBuilder.Entity<Airplane>().HasData(new Airplane[]
            {
                new Airplane()
                {
                    ID= 1,
                    Model = "Boeing 747",
                    MaxPassangers = 700,
                },
                                new Airplane()
                {
                    ID= 2,
                    Model = "Boeing A320",
                    MaxPassangers = 750,
                },
            });
            modelBuilder.Entity<Flight>().HasData(new Flight[]
            {
                new Flight()
                {
                    ID= 1,
                    AirplaneID= 1,
                    DepartureCity = "New York",
                    DepartureTime = new DateTime(2023,2,12),
                    ArrivalCity = "London",
                    ArrivalTime = new DateTime(2023,2,13),
                },
                new Flight()
                {
                    ID= 2,
                    AirplaneID= 2,
                    DepartureCity = "Amsterdam",
                    DepartureTime = new DateTime(2023,2,13),
                    ArrivalCity = "London",
                    ArrivalTime = new DateTime(2023,2,13),
                },
            });
            //modelBuilder.Entity<Airplane>().Property(a => a.Model).IsRequired().HasMaxLength(100);
            //modelBuilder.Entity<Flight>().HasKey(s => s.ID); // primary key
        }
    }
}
