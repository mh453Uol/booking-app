using System;
using System.Collections.Generic;
using BarberBooking.Entities;
using BarberBooking.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BarberBooking.ViewComponents
{
    public class ResourceListViewComponent: ViewComponent
    {
        public IViewComponentResult Invoke(BookingViewModel model)
        {
            var resources = new List<User>() {
                new User() {
                    Id = Guid.NewGuid().ToString(),
                    Firstname = "Rizwan Ali"
                },
                new User() {
                    Id = Guid.NewGuid().ToString(),
                    Firstname = "Zafran"
                }
            };

            model.Resources = resources;

            return View(model);
        }
    }
}