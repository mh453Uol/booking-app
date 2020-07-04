using System;

namespace BarberBooking.Entities
{
    public class Audit
    {
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public bool IsDeleted { get; set; }
    }
}