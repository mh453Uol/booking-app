using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarberBooking.Entities
{
    public class BookingService: Audit
    {
        public Guid BookingId { get; set; }

        [ForeignKey("BookingId")]
        public Booking Booking { get; set; }

        public Guid ServiceId { get; set; }

        [ForeignKey("ServiceId")]
        public Service Service { get; set; }
    }
}