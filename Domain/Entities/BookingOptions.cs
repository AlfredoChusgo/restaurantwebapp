using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    class BookingOptions
    {
        public int MinPartySize { get; set; }
        public int MaxPartySize { get; set; }
        public int TimeInterval { get; set; }

    }
}
