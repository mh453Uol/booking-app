using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarberBooking.Entities
{
    // Trading Hours are associated by individual employees
    public class TradingHour: Audit
    {
        public Guid Id { get; set; }
        public DayOfWeek Day { get; set; }
        public TimeSpan Open { get; set; }
        public TimeSpan Closed { get; set; }

        public string ResourceId { get; set; }

        [ForeignKey("ResourceId")]
        public User Resource { get; set; }

        public Guid TenantId { get; set; }

        [ForeignKey("TenantId")]
        public Tenant Tenant { get; set; }
    }
}