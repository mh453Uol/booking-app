using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BarberBooking.Entities;

namespace BarberBooking.Models.ViewModels
{
    public class BookingViewModel : IProgressable
    {
        public List<User> Resources { get; set; }
        public List<Service> Services { get; set; }
        public Dictionary<DateTime, List<DateTime>> Slots { get; set; }

        [Required]
        public Guid? ResourceId { get; set; }

        [Required]
        [MinLength(1)]
        public List<Guid> ServicesId { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime? Time { get; set; }

        public DateTime? From
        {
            get
            {
                return this.Time;
            }
        }

        public DateTime? To
        {
            get
            {
                var start = this.From.GetValueOrDefault();

                var services = this.Services.FindAll(s => this.ServicesId.Contains(s.Id));

                services.ForEach(s => start.Add(s.Duration));

                return start;
            }
        }

        public bool IsBookingSlotAvailable { get; set; }

        public BookingViewModel()
        {
            Resources = new List<User>();
            Services = new List<Service>();
            Slots = new Dictionary<DateTime, List<DateTime>>();

            ServicesId = new List<Guid>();

            IsBookingSlotAvailable = true;
        }

        public bool HasSelectedResource()
        {
            return ResourceId != null;
        }

        public bool HasSelectedServices()
        {
            return ServicesId.Count != 0;
        }

        public bool HasSelectedTime()
        {
            return Time != null;
        }

        public int GetProgress()
        {
            if (HasSelectedResource() && HasSelectedServices() && HasSelectedTime())
            {
                return 80;
            }

            if (HasSelectedResource() && HasSelectedServices())
            {
                return 60;
            }

            if (HasSelectedResource())
            {
                return 40;
            }

            return 20;
        }

    }
}