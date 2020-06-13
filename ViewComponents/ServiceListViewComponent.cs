using System;
using System.Collections.Generic;
using BarberBooking.Entities;
using BarberBooking.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BarberBooking.ViewComponents
{
    public class ServiceListViewComponent: ViewComponent
    {
        public IViewComponentResult Invoke(BookingViewModel model)
        {
            var services = new List<Service>() {
                new Service() {
                    Id = Guid.NewGuid(),
                    Name = "Haircut and Beard",
                    Price = 12,
                    Duration = TimeSpan.FromHours(1)
                    
                },
                new Service() {
                    Id = Guid.NewGuid(),
                    Name = "Beard",
                    Price = 5,
                    Duration = TimeSpan.FromHours(0.5)
                }
            };

            model.Services = services;

            return View(model);
        }
    }
}