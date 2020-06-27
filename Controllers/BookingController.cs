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

namespace BarberBooking.Controllers
{
    public class BookingController : Controller
    {
        private readonly ILogger<BookingController> _logger;
        private readonly SignInManager<User> _signInManager;

        public BookingController(ILogger<BookingController> logger, SignInManager<User> signInManager)
        {
            _logger = logger;
            _signInManager = signInManager;
        }

        public IActionResult Index(BookingViewModel model)
        {   
            Console.WriteLine(JsonConvert.SerializeObject(model));
            Console.WriteLine(JsonConvert.SerializeObject(ModelState.IsValid));
        
            // 1. Check if user is signed in, if so return to Booking/Create View
            // 2. If user not signed in then redirect to login page

            if (ModelState.IsValid) {
                if (!_signInManager.IsSignedIn(User)) {
                    var url = Url.Action("Create", model);
                    var title = "4. Login or Register";
                    return RedirectToPage("/Account/Login", new { area = "Identity", returnUrl = url, title = title});
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
