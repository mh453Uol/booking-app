using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BarberBooking.Models;
using BarberBooking.Models.ViewModels;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Identity;
using BarberBooking.Entities;
using Microsoft.AspNetCore.Authorization;
using BarberBooking.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BarberBooking.Controllers
{
    public class BookingController : Controller
    {
        private readonly ILogger<BookingController> _logger;
        private readonly SignInManager<User> _signInManager;
        private readonly ApplicationDbContext _dbContext;

        public BookingController(ILogger<BookingController> logger, SignInManager<User> signInManager,
            ApplicationDbContext dbContext)
        {
            _logger = logger;
            _signInManager = signInManager;
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index(BookingViewModel model)
        {
            Console.WriteLine(JsonConvert.SerializeObject(model));
            Console.WriteLine(JsonConvert.SerializeObject(ModelState.IsValid));

            // 1. If user not signed in then redirect to register page

            if (ModelState.IsValid)
            {
                if (!_signInManager.IsSignedIn(User))
                {
                    var url = Url.Action("Index", model);
                    return RedirectToPage("/Account/Register", new { area = "Identity", returnUrl = url });
                }
                else
                {
                    model.Services = await _dbContext.Services.Where(s => model.ServicesId.Contains(s.Id)).ToListAsync();
                    model.Resources = new List<User>() { 
                        await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(f => f.Id == model.ResourceId.Value.ToString()) 
                    };
                }
            }

            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> Create(BookingViewModel model)
        {
            // 1. If model is valid
            //  1.1 If booking slot available
            //      - Create booking
            //  1.2 If booking slot NOT available
            //      - Display message to user with option to change slots

            if (ModelState.IsValid)
            {
                var bookings = await _dbContext.Bookings.AsNoTracking().AnyAsync(b => b.From > model.To || b.To < b.From);

                if (bookings)
                {
                    model.IsBookingSlotAvailable = false;
                    return View(model);
                }
            }

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
