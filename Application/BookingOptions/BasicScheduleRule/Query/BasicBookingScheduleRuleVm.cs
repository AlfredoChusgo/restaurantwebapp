using System;
using System.Collections.Generic;
using Application.BookingOptions.Queries;

namespace Application.BookingOptions.BasicScheduleRule.Query
{
    public class BasicBookingScheduleRuleVm
    {
        public DropDownItemInfo StartTimeBookingRule { get; set; }
        public DropDownItemInfo EndTimeBookingRule { get; set; }

        public BasicBookingScheduleRuleVm()
        {
            StartTimeBookingRule = new DropDownItemInfo();
            EndTimeBookingRule = new DropDownItemInfo();
        }
    }
}
