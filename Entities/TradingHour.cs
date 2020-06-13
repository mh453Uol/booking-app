using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarberBooking.Entities
{
    public class TradingHour: Audit
    {
        public Guid Id { get; set; }
        public DayOfWeek Day { get; set; }
        public TimeSpan Open { get; set; }
        public TimeSpan Closed { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}