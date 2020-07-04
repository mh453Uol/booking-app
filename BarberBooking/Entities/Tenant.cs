using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BarberBooking.Entities
{
    public class Tenant : Audit
    {
        public Tenant()
        {
            Users = new List<User>();
        }

        public Guid Id { get; set; }

        // Unique string to present this tenant e.g {majid-shop}.tappr.co.uk
        [Required]
        [MaxLength(256)]
        public string Slug { get; set; }

        [Required]
        [MaxLength(256)]
        public string Name { get; set; }

        public List<User> Users { get; set; }

        public List<Service> Services { get; set; }
    }
}