using System;
using System.Collections.Generic;
using Application.BookingOptions.Queries;
using Domain.Entities;

namespace Application.BookingOptions.BasicScheduleRule.Query
{
    public class SchedulingExceptionBookingRuleListVm
    {
        public List<SchedulingExceptionBookingRule> List { get; set; }

        public SchedulingExceptionBookingRuleListVm()
        {
            List = new List<SchedulingExceptionBookingRule>();
        }
    }
}
