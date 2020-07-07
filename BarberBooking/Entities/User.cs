using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace BarberBooking.Entities
{
    public class User : IdentityUser
    {
        public User() : base()
        {

            SlotInterval = TimeSpan.FromMinutes(30);
            BookableHours = new List<TradingHour>() {
                new TradingHour() { Day = DayOfWeek.Monday, Open = new TimeSpan(09,00,00), Closed = new TimeSpan(17,00,00) },
                new TradingHour() { Day = DayOfWeek.Tuesday, Open = new TimeSpan(09,00,00), Closed = new TimeSpan(17,00,00) },
                new TradingHour() { Day = DayOfWeek.Wednesday, Open = new TimeSpan(09,00,00), Closed = new TimeSpan(17,00,00) },
                new TradingHour() { Day = DayOfWeek.Wednesday, Open = new TimeSpan(09,00,00), Closed = new TimeSpan(17,00,00) },
                new TradingHour() { Day = DayOfWeek.Thursday, Open = new TimeSpan(09,00,00), Closed = new TimeSpan(17,00,00) },
                new TradingHour() { Day = DayOfWeek.Friday, Open = new TimeSpan(09,00,00), Closed = new TimeSpan(17,00,00) },
                new TradingHour() { Day = DayOfWeek.Saturday, Open = new TimeSpan(09,00,00), Closed = new TimeSpan(17,00,00) },
                new TradingHour() { Day = DayOfWeek.Sunday, Open = new TimeSpan(09,00,00), Closed = new TimeSpan(17,00,00) }
            };
        }

        [Required]
        [MaxLength(256)]

        public string Firstname { get; set; }

        [Required]
        [MaxLength(256)]
        public string Lastname { get; set; }

        public Guid? TenantId { get; set; }

        [ForeignKey("TenantId")]
        public Tenant Tenant { get; set; }

        public List<TradingHour> BookableHours { get; set; }

        public TimeSpan? SlotInterval { get; set; }
    }
}