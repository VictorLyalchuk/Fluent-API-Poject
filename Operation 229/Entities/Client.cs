using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Operation_229.Entities
{
    [Table("Passengers")]
    public class Client
    {
        public int ID { get; set; }
        [Required] // NOT NULL
        [MaxLength(100)] // nvarchar 100
        [Column("FirstName")]
        public string Name { get; set; }
        [Required]
        [MaxLength(100)]
        public string Email { get; set; }
        public DateTime? Birthday { get; set; }  // NULL
        public ICollection<Flight> flights { get; set; }
    }
}
