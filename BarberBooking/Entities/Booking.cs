using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarberBooking.Entities
{
    public class Booking: Audit
    {
        public Guid Id { get; set; }

        [MaxLength(1000)]
        public string Message { get; set; }

        [Required]
        public string ResourceId { get; set; }
        
        [ForeignKey("ResourceId")]    
        public User Resource { get; set; }

        public Guid TenantId { get; set; }

        [ForeignKey("TenantId")]
        public Tenant Tentant { get; set; }
        
        public ICollection<BookingService> Services { get; set; }
        public Decimal TotalPrice { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}