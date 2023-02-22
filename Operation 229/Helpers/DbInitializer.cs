using Microsoft.EntityFrameworkCore;
using Operation_229.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Operation_229.Helpers
{
    internal static class DbInitializer
    {
        public static void SeedAirplanes(this ModelBuilder modelBuilder)
        {
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

        }
        public static void SeedFlights(this ModelBuilder modelBuilder)
        {
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
        }
    }
}
