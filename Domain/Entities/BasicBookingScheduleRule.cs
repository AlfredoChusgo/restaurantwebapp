using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class BasicBookingScheduleRule
    {
        public int Id { get; set; }
        public int StartTimeId { get; set; }
        public int EndTimeId { get; set; }
        public bool MondaySelected { get; set; }
        public bool TuesdaySelected { get; set; }
        public bool WednesdaySelected { get; set; }
        public bool ThursdaySelected { get; set; }
        public bool FridaySelected { get; set; }
        public bool SaturdaySelected { get; set; }
        public bool SundaySelected { get; set; }
        
        //Todo validate that the basic rule is not inside other rule.
    }
}
