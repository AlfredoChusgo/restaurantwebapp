using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Booking.Queries;
using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {
        }

        //public ApplicationDbContext()
        //{
        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    string connectionString = "Server=127.0.0.1; port=3306; Database=booking_app_test; User=root; Password=;";
        //    optionsBuilder.UseMySql(connectionString,ServerVersion.AutoDetect(connectionString));
        //}
        public DbSet<BookingItem> BookingItems { get; set; }
        public DbSet<BasicBookingScheduleRule> BasicBookingScheduleRules { get; set; }

        public DbSet<SchedulingExceptionBookingRule> SchedulingExceptionBookingRule { get; set; }
        public DbSet<BookingOption> BookingOptions { get; set; }
        //public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        //{
        //    throw new NotImplementedException();
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookingItem>().ToTable("BookingItems");
            modelBuilder.Entity<BasicBookingScheduleRule>().ToTable("BasicBookingScheduleRules");
            modelBuilder.Entity<BookingOption>().ToTable("BookingOptions");
            //modelBuilder.Entity<SchedulingBookingRule>().ToTable("SchedulingBookingRules");
            //modelBuilder.Entity<SchedulingExceptionBookingRule>().ToTable("SchedulingExceptionBookingRules");
        }
    }
}
