using BarberBooking.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BarberBooking.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<TradingHour> OpeningHours { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<BookingService>().HasKey(bs => new { bs.BookingId, bs.ServiceId });
            builder.Entity<BookingService>()
                .HasOne(bs => bs.Booking)
                .WithMany(b => b.Services)
                .HasForeignKey(bs => bs.BookingId);
            
            builder.Entity<BookingService>()
                .HasOne(bs => bs.Service)
                .WithMany()
                .HasForeignKey(bs => bs.ServiceId);

            builder.Entity<Tenant>().HasMany(r => r.Users).WithOne(r => r.Tenant).IsRequired(false);
            builder.Entity<Tenant>().HasOne(r => r.CreatedBy).WithMany().HasForeignKey(r => r.CreatedById);
            builder.Entity<Tenant>().HasOne(r => r.UpdatedBy).WithMany().HasForeignKey(r => r.UpdatedById);

            builder.Entity<TradingHour>().HasOne(r => r.Resource).WithOne();
            builder.Entity<TradingHour>().HasOne(r => r.CreatedBy).WithMany().HasForeignKey(r => r.CreatedById);
            builder.Entity<TradingHour>().HasOne(r => r.UpdatedBy).WithMany().HasForeignKey(r => r.UpdatedById);

            builder.Entity<Booking>().HasMany(r => r.Services);

            base.OnModelCreating(builder);
        }
    }
}
