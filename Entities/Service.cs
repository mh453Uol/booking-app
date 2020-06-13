using System;
using System.ComponentModel.DataAnnotations;

namespace BarberBooking.Entities
{
    public class Service: Audit
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(256)]
        public string Name { get; set; }

        [Required]
        public TimeSpan Duration { get; set; }

        [Required]
        public decimal Price { get; set; }

        [MaxLength(256)]
        public string Description { get; set; }
    }
}