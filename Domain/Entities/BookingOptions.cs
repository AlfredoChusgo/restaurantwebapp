using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class BookingOptions
    {
        public int MinPartySize { get; set; }
        public int MaxPartySize { get; set; }
        public int EarlyBooking { get; set; }
        public int LateBooking { get; set; }

    }
}
