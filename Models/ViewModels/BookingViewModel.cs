using System;
using System.Collections.Generic;
using BarberBooking.Entities;

namespace BarberBooking.Models.ViewModels
{
    public class BookingViewModel
    {
        public List<User> Resources { get; set; }
        public List<Service> Services { get; set; }
        public Dictionary<DateTime, List<DateTime>> Slots { get; set; }

        public Guid ResourceId { get; set; }
        public List<Guid> ServicesId { get; set; }
        public DateTime Time { get; set; }

        public BookingViewModel()
        {
            Resources = new List<User>();
            Services = new List<Service>();
            Slots = new Dictionary<DateTime, List<DateTime>>();

            ServicesId = new List<Guid>();

        }

        public bool HasSelectedResource()
        {
            return ResourceId != Guid.Empty;
        }

        public bool HasSelectedServices()
        {
            return ServicesId.Count != 0;
        }

        public bool HasSelectedTime()
        {
            return Time != DateTime.MinValue;
        }

        public int GetFormProgress()
        {
            if (HasSelectedResource() && HasSelectedServices() && HasSelectedTime())
            {
                return 100;
            }

             if (HasSelectedResource() && HasSelectedServices())
            {
                return 75;
            }

            if (HasSelectedResource())
            {
                return 50;
            }

            return 25;
        }
    }
}