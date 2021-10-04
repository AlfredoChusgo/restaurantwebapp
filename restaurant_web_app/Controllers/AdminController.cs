using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Booking.Queries;
using Domain.Entities;
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

        public IActionResult Index()
        {
            GetAllBookingQuery query = new GetAllBookingQuery();
            
            List<BookingItem> BookingList = query.Execute();
            return View(BookingList);
        }

        public IActionResult BookingOptions()
        {
            return View();
        }
    }
}
