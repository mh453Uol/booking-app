using System;
using System.Collections.Generic;
using BarberBooking.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using BarberBooking.Utilities;

namespace BarberBooking.ViewComponents
{
    public class SlotListViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(BookingViewModel model)
        {
            // now = 31/05/2020 14:17 
            // slot duration is 10 mins 
            // so slots needs to be as follows 14:20, 14:30, 14:40, ...

            var resourceStartTime = new TimeSpan(09, 00, 00);
            var resourceEndTime = new TimeSpan(19, 00, 00);

            var slotDuration = TimeSpan.FromMinutes(10);

            var now = DateTime.Now.RoundUp(slotDuration);

            if(now.TimeOfDay > resourceEndTime) {
                now = DateTime.Today.AddDays(1).Date;
            }

            Console.WriteLine(now);
          
            var end = now.AddDays(7).Add(resourceEndTime);

            Console.WriteLine(end);
            Console.WriteLine("Hello");

            var slots = new Dictionary<DateTime, List<DateTime>>();
            while (now <= end)
            {
                if (!slots.ContainsKey(now.Date))
                {
                    slots.Add(now.Date, new List<DateTime>());
                }

                if (now.TimeOfDay >= resourceStartTime && now.TimeOfDay <= resourceEndTime)
                {
                    slots[now.Date].Add(now);
                }

                now = now.Add(slotDuration);
            }

            Console.WriteLine(slots.Count);

            model.Slots = slots;

            return View(model);
        }
    }
}