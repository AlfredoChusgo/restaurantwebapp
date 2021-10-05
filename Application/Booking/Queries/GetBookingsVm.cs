using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Booking.Queries
{
    public class GetBookingsVm
    {
        public List<BookingItem> BookingList { get; set; }
        public int ItemCount { get; set; }

        public GetBookingsVm()
        {
            BookingList = new List<BookingItem>();
            ItemCount = 0;
        }
    }
}
