using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.BookingOptions.Queries;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using restaurant_web_app.BussinessLogicLayer.BookingOptionsRazorHelper;

namespace restaurant_web_app.ViewModels
{
    public class BookingOptionsViewModel
    {
        public BookingOption BookingOption { get; set; }
        public SelectList SelectListMinPartySizeOptions { get; set; }
        public SelectList SelectListMaxPartySizeOptions { get; set; }
        public SelectList SelectListEarlyBookingOptions { get; set; }
        public SelectList SelectListLateBookingOptions { get; set; }

        public BookingOptionsViewModel(BookingOptionsVm bookingOptionsVm)
        {
            BookingOption = new BookingOption();
            SelectListMinPartySizeOptions = SelectListFactory.GetSelectList(bookingOptionsVm.MinPartySizeOptions);
            SelectListMaxPartySizeOptions = SelectListFactory.GetSelectList(bookingOptionsVm.MaxPartySizeOptions);
            SelectListEarlyBookingOptions = SelectListFactory.GetSelectList(bookingOptionsVm.EarlyBookingOptions);
            SelectListLateBookingOptions = SelectListFactory.GetSelectList(bookingOptionsVm.LateBookingOptions);
            BookingOption = bookingOptionsVm.BookingOption;
        }
    }
}
