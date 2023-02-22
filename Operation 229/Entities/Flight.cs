using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Operation_229.Entities
{
    public class Flight
    {
        [Key] //primary key
        public int ID { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }
        //Relationship type : one to many
        public int AirplaneID { get; set; }
        public Airplane airplanes { get; set; }
        public ICollection<Client> clients { get; set; }

    }
}
