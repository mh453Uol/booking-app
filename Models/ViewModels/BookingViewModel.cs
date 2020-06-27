using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BarberBooking.Entities;

namespace BarberBooking.Models.ViewModels
{
    public class BookingViewModel: IProgressable
    {
        public List<User> Resources { get; set; }
        public List<Service> Services { get; set; }
        public Dictionary<DateTime, List<DateTime>> Slots { get; set; }

        [Required]
        public Guid? ResourceId { get; set; }

        [Required] 
        public List<Guid> ServicesId { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime? Time { get; set; }

        public BookingViewModel()
        {
            Resources = new List<User>();
            Services = new List<Service>();
            Slots = new Dictionary<DateTime, List<DateTime>>();

            ServicesId = new List<Guid>();

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