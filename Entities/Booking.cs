using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarberBooking.Entities
{
    public class Booking: Audit
    {
        public Guid Id { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        [MaxLength(1000)]
        public string Message { get; set; }

        public string ResourceId { get; set; }
        
        [ForeignKey("ResourceId")]    
        public User Resource { get; set; }
        
        public List<Service> Services { get; set; }
        public Decimal TotalPrice { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}