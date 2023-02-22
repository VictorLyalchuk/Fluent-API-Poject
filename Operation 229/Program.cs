using Operation_229.Entities;
using System;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using static System.Console;

namespace Operation_229
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AirplanesDBContext Context = new AirplanesDBContext();
            Context.Clients.Add(new Client()
            {
                Name = "Tonny",
                Email = "Mutter@gmail.com",
                Birthday = new DateTime(2002, 7, 12),
            });
            Context.SaveChanges();

            foreach (var c in Context.Clients)
            {
                WriteLine($"Client: {c.ID} {c.Name} {c.Email} {c.Birthday}");
            }
            var filter = Context.Flights.Where(f => f.ArrivalCity == "London").OrderBy(a => a.ArrivalTime);
            
            foreach (var f in filter)
            {
                WriteLine($"Flights: {f.ID} {f.DepartureCity} {f.ArrivalTime}");
            }

            var result = Context.Clients.Find(1);
            if(result != null)
            {
                Context.Clients.Remove(result);
                Context.SaveChanges();
            }
        }
    }
}
