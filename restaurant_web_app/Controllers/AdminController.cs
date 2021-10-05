using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Booking.Queries;
using Domain.Entities;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace restaurant_web_app.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public AdminController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(BookingStatus status,bool applyFilter = false)
        {
            GetBookingFilteredQuery query = new GetBookingFilteredQuery(status,applyFilter);
            
            GetBookingsVm bookingVm = query.Execute();

            return View(bookingVm);
        }

        public IActionResult BookingOptions()
        {
            return View();
        }

        public IActionResult BookingEdit(int id)
        {
            BookingItem item = new GetBookingDetail(id).Execute();

            return View(item);
        }

        public IActionResult BookingDetail(int id)
        {
            BookingItem item = new GetBookingDetail(id).Execute();

            return View(item);
        }

        [HttpPost]
        public IActionResult BookingUpdate([Bind] BookingItem item)
        {
            //BookingItem item = new GetBookingDetail(id).Execute();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddBooking()
        {
            //BookingItem item = new GetBookingDetail(id).Execute();
            return View();
        }

        [HttpPost]
        public IActionResult AddBooking([Bind] BookingItem item)
        {
            //BookingItem item = new GetBookingDetail(id).Execute();
            //todo bug with BookingStatus always 0
            return View();
        }
    }
}
