using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Operation_229.Entities
{
    // entity class
    public class Airplane
    {
        public int ID { get; set; }
        [Required] // NOT NULL
        [MaxLength(100)] // nvarchar 100
        public string Model { get; set; }
        public int MaxPassangers { get; set; }
        public ICollection<Flight> flights { get; set; }
    }
}
