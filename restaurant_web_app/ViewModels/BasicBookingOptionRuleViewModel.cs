﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.BookingOptions.BasicScheduleRule.Query;
using Application.BookingOptions.Queries;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using restaurant_web_app.BussinessLogicLayer.BookingOptionsRazorHelper;

namespace restaurant_web_app.ViewModels
{
    public class BasicBookingOptionRuleViewModel
    {
        public BasicBookingScheduleRule BasicBookingScheduleRule { get; set; }
        public SelectList SelectStartTimeBookingRule { get; set; }
        public SelectList SelectEndTimeBookingRule { get; set; }

        public BasicBookingOptionRuleViewModel(BasicBookingScheduleRuleVm vm)
        {
            BasicBookingScheduleRule = new BasicBookingScheduleRule();
            SelectStartTimeBookingRule = SelectListFactory.GetSelectList(vm.StartTimeBookingRule);
            SelectEndTimeBookingRule = SelectListFactory.GetSelectList(vm.EndTimeBookingRule);
        }
    }
}