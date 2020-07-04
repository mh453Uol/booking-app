using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BarberBooking.Entities;
using BarberBooking.Persistence;
using Microsoft.AspNetCore.Identity;

public class SeedData
{
    private ApplicationDbContext _context { get; set; }
    private RoleManager<IdentityRole> _roleManager { get; set; }
    private UserManager<User> _userManager { get; set; }
    public SeedData(ApplicationDbContext applicationDbContext,
        RoleManager<IdentityRole> roleManager,
        UserManager<User> userManager)
    {
        _context = applicationDbContext;
        _roleManager = roleManager;
        _userManager = userManager;
    }

    public async Task Initialize()
    {
        await _context.Database.EnsureCreatedAsync();

        if (!_context.Roles.Any())
        {
            string[] roles = new string[] { "Administrator", "Manager", "Employee", "User" };


            foreach (var role in roles)
            {
                var exist = await _roleManager.RoleExistsAsync(role);

                if (!exist)
                {
                    await _roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            await _context.SaveChangesAsync();
        }

        if (!_context.Tenants.Any())
        {
            _context.Tenants.Add(new Tenant()
            {
                Name = "Freshcuts Barbers",
                Slug = "freshcuts-barbers",
                Services = new List<Service>() {
                    new Service() { Name = "Short Back & Sides", Duration = TimeSpan.FromMinutes(30), Price = 7.00M},
                    new Service() { Name = "Skin Fade", Duration = TimeSpan.FromMinutes(30), Price = 10.00M}
                }
            });

            await _context.SaveChangesAsync();
        }

        if (!_context.Users.Any())
        {
            var employee = new User()
            {
                UserName = "za@test.com",
                Firstname = "Za",
                Lastname = "Al",
                Email = "za@test.com",
                Tenant = _context.Tenants.FirstOrDefault(t => t.Name == "Freshcuts Barbers")
            };

            var addedUser = await _userManager.CreateAsync(employee, "FakePa55word#");

            if (addedUser.Succeeded)
            {
                await _userManager.AddToRoleAsync(employee, "Employee");
            }

            await _context.SaveChangesAsync();
        }
    }
}