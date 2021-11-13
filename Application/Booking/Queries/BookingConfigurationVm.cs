using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Booking.Queries
{
    public class BookingConfigurationVm
    {
        public List<int> PartySizeDictionary { get; set; }
        public Dictionary<int,string> StatusDictionary { get; set; }
        public List<DateTime> DisabledDatesDictionary { get; set; }

    }
}
