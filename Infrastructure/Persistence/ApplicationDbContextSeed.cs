using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Booking.Queries;
using Domain.Entities;

namespace Infrastructure.Persistence
{
    public class ApplicationDbContextSeed
    {
        public static void SeedSampleData(ApplicationDbContext context, int count)
        {
            var data = new GetAllBookingQuery();
            List<BookingItem> bookingItems = data.SeedData(count);

            bookingItems.ForEach(item =>
            {
                context.Add(item);
            });
            
            context.SaveChanges();
        }
    }
}
